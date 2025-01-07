<script setup>

    const pageTitle         = ref('Content Main')
    const showImageEditor   = ref(false)


</script>

<template>

    <div class="relative" id="adminNotes">

        <div class="z-0 bg-gradient-main h-[500px] absolute top-0 left-0 right-0"></div>

        <div class="p-5 pt-5 sm:p-10 sm:pt-5 pb-14">
            <div class="flex justify-between items-center mb-7 relative z-20">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ pageTitle }}</h2>
                <span class="flex flex-wrap gap-1.5">
                    <button class="btn-primary" @click="showImageEditor=true">View Images</button>
                </span>
            </div>
            <div class="w-full min-h-[400px] relative z-20">
                Content Starts Here.
            </div>
        </div>

        <ImageEditor v-model:show="showImageEditor"></ImageEditor>

    </div>  

</template>