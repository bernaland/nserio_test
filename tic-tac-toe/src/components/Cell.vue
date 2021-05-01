<template>
    <td>
        <button :class="buttonClasses" @click="onButtonClick" :disabled="isDisabled">
            <!-- <img :src="backgroundImage" /> -->
        </button>
    </td>
</template>
<script>
export default {
    name:'Cell',
    props:{
        figure: {
            type: String,
            required: false
        }
    },
    computed:{
        // backgroundImage(){
        //     let image = null;
        //     let self = this;
        //     if (self.figure === 'x') {
        //         image = "../assets/x.png";
        //     } else if (self.figure === 'o') {
        //         image = "../assets/o.png";
        //     }
        //     return image != null ? require(image):null;
        // }
        buttonClasses(){
            let cssClasses = ['field'];
                let self = this;
            if (self.figure === 'x') {
                cssClasses.push('x-figure');
            } else if (self.figure === 'o') {
                cssClasses.push('o-figure');
            }

            return cssClasses;
        },
        isDisabled() {
            return this.figure!=='';
        }
    },
    methods: {
        onButtonClick(){
            this.$emit("cellClick");
        }
    },
}
</script>
<style scoped>
button.field {
    min-width: 150px;
    min-height: 150px;
}

.o-figure {
    background-image: url('../assets/o.png')
}

.x-figure {
    background-image: url('../assets/x.png')
}
</style>