<script setup>

    const homeTitle     = ref("Welcome")
    const confirmSave   = () => alert('Confirm Save')

</script>

<template>

    <div class="p-5 sm:p-10 pt-10 pb-14 grow h-full min-h-[600px] bg-gradient-main">

        <div class="flex flex-wrap gap-5 mb-7" id="HomeView">
            <div class="w-full flex justify-between items-center">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ homeTitle }}</h2>
                <span class="flex flex-wrap gap-1.5"> 
                    <button  class="custom-button" @click="confirmSave">Save</button>
                </span>
            </div>
        </div> 

        <div class="mb-5">
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis voluptatem iusto quas
            numquam ea odit vel amet laborum facere eveniet mollitia in libero voluptatum quo, 
            consectetur quia veniam culpa? Pariatur.
        </div> 

        <div class="mb-5">
            Amet consectetur adipisicing elit. Reiciendis voluptatem 
            iusto quas numquam ea odit vel amet laborum facere eveniet mollitia in libero voluptatum quo, 
            consectetur quia veniam culpa? Pariatur. Reiciendis voluptatem iusto quas numquam.
        </div> 

    </div>  

</template>