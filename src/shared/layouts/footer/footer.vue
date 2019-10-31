<template>
    <div class="footer">
        <h2><a href="https://anuitex.com/">Created by Anuitex</a></h2>
    </div>
</template>

<script>
export default {
    name: 'Footer'
}
</script>

<style scoped>
    .footer {
        position: absolute;
        bottom: 0;
        display: flex;
        flex-direction: column;
        width: 100%;
        background-color: #707070;
        padding: 25px 0 25px 0;
    }

    h2 {
        color: white;
    }

    a {
        color: white;
        text-decoration: none;
    }

    a:hover {
        color: white;
        text-decoration: none;
    }

    @media (max-width: 650px) {
        h2 {
            font-size: 20px;
        }
    }
</style>