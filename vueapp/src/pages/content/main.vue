<script setup>

    const pageTitle         = ref('Content Main')
    const showImageEditor   = ref(false)

</script>

<template>

    <div class="relative" id="ContentMain">

        <ImageEditor v-model:showModal="showImageEditor"></ImageEditor>

        <div class="z-0 bg-gradient-main h-[300px] absolute top-0 left-0 right-0"></div>

        <div class="z-10 p-5 pt-5 sm:p-10 sm:pt-5">

            <div class="flex justify-between items-center mb-7 relative z-20">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ pageTitle }}</h2>
                <span class="flex flex-wrap gap-1.5">
                    <button class="btn-primary" @click="showImageEditor=true">View Images</button>
                </span>
            </div>

            <div class="w-full min-h-[400px] relative z-20">
                Lorem ipsum, dolor sit amet consectetur adipisicing elit. 
                Esse aliquam distinctio odio soluta, quibusdam placeat, incidunt ad non, 
                illo alias est quaerat nesciunt iure repudiandae dolor! 
                Cum odit aperiam debitis.
            </div>
        </div>

    </div>  

</template>