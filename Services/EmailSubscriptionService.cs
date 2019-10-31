using System.Collections.Generic;
using System.Linq;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Threading.Tasks;
using Entities;
using Services.Interfaces;
using System;
using Repositories.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using System.IO;

namespace Services
{
    public class EmailSubscriptionService : IEmailSubscriptionService
    {
        private ISubscriptionRepository _subscriptionRepository;

        public EmailSubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<List<Article>> GetLatestNewsInCategory(Categories category)
        {
            List<Article> newsArticles = new List<Article>();
            bool isChecked = false;
            int pageCount = 1;

            do
            {
                var result = await GetLatestNewsFromApi(category, pageCount);
                newsArticles.AddRange(result.Articles);
                pageCount++;

                isChecked = newsArticles.Last().PublishedAt < DateTime.Today.AddDays(-1);
            }
            while (!isChecked);

            return newsArticles;
        }

        public async Task<List<Subscription>> GetSubscroptionsByCategory(Categories category)
        {
            List<Subscription> result = await _subscriptionRepository.GetSubscriptionsByCategoryAsync(category);
            return result;
        }

        public async Task SendNewsToSubscribers(List<Article> news, List<Subscription> subscriptions)
        {
            string smptServer = "smtp.gmail.com";
            string smplLogin = "CampaTstPrereq@gmail.com"; //TODO: Change creds
            string smtpPassword = "Yrq3AwZAtMTY";

            try
            {
                var emailMessage = await PrepareEmailMessage(news);

                foreach (Subscription sub in subscriptions)
                {
                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync(smptServer, 465, true);
                        await client.AuthenticateAsync(smplLogin, smtpPassword);
                        emailMessage.To.Add(new MailboxAddress(string.Empty, sub.Email));

                        await client.SendAsync(emailMessage);
                        await client.DisconnectAsync(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task<ArticlesResult> GetLatestNewsFromApi(Categories category, int page = 1)
        {
            var newsApiClient = new NewsApiClient("8a4d40be944c4dbeb2d365c05cfe3eab");
            const int pageSize = 10;

            ArticlesResult newsResponse = await newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
            {
                Category = category,
                Page = page,
                PageSize = pageSize,
                Country = Countries.US
            });

            return newsResponse;
        }

        private async Task<MimeMessage> PrepareEmailMessage(List<Article> news)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("News for you!", "noreply@plz.2me"));
            emailMessage.Subject = "We got some news for you!";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = await BuildEmailText(news)
            };

            return emailMessage;
        }

        private async Task<string> BuildEmailText(List<Article> news)
        {
            string emailBoby = String.Empty;
            string newsWrapper = String.Empty;
            string content = String.Empty;

            using (StreamReader reader = new StreamReader("../email-template/news.html"))
            {
                newsWrapper = await reader.ReadToEndAsync();
            }

            foreach (Article article in news)
            {
                string articleContent = newsWrapper;
                articleContent = articleContent.Replace("{Title}", article.Title);
                articleContent = articleContent.Replace("{ImageUrl}", article.UrlToImage);
                articleContent = articleContent.Replace("{Url}", article.Url);

                content += articleContent;
            }

            using (StreamReader reader = new StreamReader("../email-template/index.html"))
            {
                emailBoby = await reader.ReadToEndAsync();
            }

            emailBoby = emailBoby.Replace("{News}", content);

            return emailBoby;
        }
    }
}
