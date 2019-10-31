<template>
    <canvas ref='canvas' id='canvas'></canvas>
</template>
<script>
export default {
    name: 'CanvasBg',
    data() {
        return {
            provider: {
                context: null
            },
            dots: [],
            //(design) quantity
            dotsCol: 120,
        }
    },
    provide () {
        return {
            provider: this.provider
        }
    },
    methods: {
        addDot() {
            for (let j = 0; j < this.dotsCol; j++) {
                this.dots.push({
                x: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientWidth),
                y: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientHeight),
                //(design) Color of dots
                color: '#e6e6e6',
                //(design) dots radius
                radius: 3,
                stepCount: Math.floor(Math.random() * 135),
                direction: Math.floor(Math.random() * 8),
                });
            }

            this.drawDot();
            },

            drawDot() {
            this.provider.context.clearRect(0, 0, this.$refs['canvas'].parentElement.clientWidth, this.$refs['canvas'].parentElement.clientHeight);

            for (let i = 0; i < this.dots.length; i++) {
                if (this.dots[i].stepCount === 0) {
                    this.dots[i].stepCount = Math.floor(Math.random() * 135);
                    this.dots[i].direction = Math.floor(Math.random() * 8);
                } else {
                    this.dots[i].stepCount--;
                }

                switch (this.dots[i].direction) {
                case 0 :
                    // top
                    this.dots[i].y = this.dots[i].y - 1;
                    break;
                case 1 :
                    // right
                    this.dots[i].x = this.dots[i].x + 1;
                    break;
                case 2 :
                    // bottom
                    this.dots[i].y = this.dots[i].y + 1;
                    break;
                case 3 :
                    // left
                    this.dots[i].x = this.dots[i].x - 1;
                    break;
                case 4 :
                    // right-top
                    this.dots[i].x = this.dots[i].x + 1;
                    this.dots[i].y = this.dots[i].y - 1;
                    break;
                case 5 :
                    // right-bottom
                    this.dots[i].x = this.dots[i].x + 1;
                    this.dots[i].y = this.dots[i].y + 1;
                    break;
                case 6 :
                    // left-bottom
                    this.dots[i].x = this.dots[i].x - 1;
                    this.dots[i].y = this.dots[i].y + 1;
                    break;
                case 7 :
                    // left-top
                    this.dots[i].x = this.dots[i].x - 1;
                    this.dots[i].y = this.dots[i].y - 1;
                    break;
                }

                if (this.dots[i].x < -10 || this.dots[i].x > this.$refs['canvas'].parentElement.clientWidth + 10 || this.dots[i].y < -10 || this.dots[i].y > this.$refs['canvas'].parentElement.clientHeight + 10) {
                    this.dots[i].stepCount = 0;
                }
                    this.provider.context.fillStyle = this.dots[i].color;
                    this.provider.context.beginPath();
                    this.provider.context.arc(this.dots[i].x, this.dots[i].y, this.dots[i].radius, 0, 2 * Math.PI, true);
                    this.provider.context.fill();
                for (let j = 0; j < this.dots.length; j++) {
                    const differenceX = this.dots[j].x - this.dots[i].x;
                    const differenceY = this.dots[j].y - this.dots[i].y;
                    const squareDiffX = differenceX * differenceX;
                    const squareDiffY = differenceY * differenceY;
                    const summ = squareDiffX + squareDiffY;
                    const sqrtOfSumm = Math.sqrt(summ);

                    if (sqrtOfSumm < 150) {
                        this.provider.context.beginPath();
                        // (design) Line color
                        this.provider.context.strokeStyle = '#dedede';
                        this.provider.context.moveTo(this.dots[i].x, this.dots[i].y);
                        this.provider.context.lineTo(this.dots[j].x, this.dots[j].y);
                        this.provider.context.stroke();
                    }
                }
            }

            this.timer = setTimeout(() => {
                this.drawDot();
            }, 15);
        },

        handleResize() {
            this.$refs['canvas'].width = window.innerWidth;
            this.$refs['canvas'].height = window.innerHeight;
            this.provider.context = this.$refs['canvas'].getContext('2d', "mybackground", window.innerHeight, window.innerWidth);

            if (window.innerWidth <= 840) {
                this.dotsCol = 80;
                this.dots = [];
                for (let j = 0; j < this.dotsCol; j++) {
                    this.dots.push({
                    x: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientWidth),
                    y: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientHeight),
                    //(design) Color of dots
                    color: '#e6e6e6',
                    //(design) dots radius
                    radius: 3,
                    stepCount: Math.floor(Math.random() * 135),
                    direction: Math.floor(Math.random() * 8),
                    });
                }
            }

            if (window.innerWidth < 640) {
                this.dotsCol = 60;
                this.dots = [];
                for (let j = 0; j < this.dotsCol; j++) {
                    this.dots.push({
                    x: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientWidth),
                    y: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientHeight),
                    //(design) Color of dots
                    color: '#e6e6e6',
                    //(design) dots radius
                    radius: 3,
                    stepCount: Math.floor(Math.random() * 135),
                    direction: Math.floor(Math.random() * 8),
                    });
                }
            }

            if (window.innerWidth > 840) {
                this.dotsCol = 100;
                this.dots = [];
                for (let j = 0; j < this.dotsCol; j++) {
                    this.dots.push({
                    x: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientWidth),
                    y: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientHeight),
                    //(design) Color of dots
                    color: '#e6e6e6',
                    //(design) dots radius
                    radius: 3,
                    stepCount: Math.floor(Math.random() * 135),
                    direction: Math.floor(Math.random() * 8),
                    });
                }
            }

            if (window.innerHeight > 1024) {
                this.dotsCol = 130;
                this.dots = [];
                for (let j = 0; j < this.dotsCol; j++) {
                    this.dots.push({
                    x: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientWidth),
                    y: Math.floor(Math.random() * this.$refs['canvas'].parentElement.clientHeight),
                    //(design) Color of dots
                    color: '#e6e6e6',
                    //(design) dots radius
                    radius: 3,
                    stepCount: Math.floor(Math.random() * 135),
                    direction: Math.floor(Math.random() * 8),
                    });
                }
            }

        }
    },
    mounted() {
        this.provider.context = this.$refs['canvas'].getContext('2d');
        this.$refs['canvas'].width = window.innerWidth;
        this.$refs['canvas'].height = window.innerHeight;
        this.provider.context.globalCompositeOperation='destination-over';
        this.addDot();
        window.addEventListener('resize', this.handleResize);
        this.handleResize();
    },
}
</script>

<style scoped>
    #canvas {
        position: fixed;
        top: 0; 
        right: 0; 
        left: 0; 
        bottom: 0;
    }
</style>