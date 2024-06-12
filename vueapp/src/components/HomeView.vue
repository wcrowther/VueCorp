<script setup>

    const homeTitle     = ref("Welcome to VueCorp")
    // const confirmSave   = () => alert('Confirm Save')

</script>

<template>

    <div class="p-5 pt-5 sm:p-10 sm:pt-5 pb-14 grow 
        leading-relaxed h-full min-h-[600px] bg-gradient-main">

        <div class="flex flex-wrap gap-5 mb-7" id="HomeView">
            <div class="w-full flex justify-between items-center">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ homeTitle }}</h2>
                <span class="flex flex-wrap gap-1.5"> 
                    <!-- <button  class="custom-button" @click="confirmSave">Save</button> -->
                </span>
            </div>
        </div> 

        <div class="mb-5">
            VueCorp is an opensource project to provide a streamlined DotNet solution that combines
            the latest Vuejs 3.4 Composition API technology with the latest .Net 8.0 Minimal API 
            backend. This project is not intended for commercial profit but rather for .NET developers
            as an educational doorway into these technologies.
        </div> 

        <div class="mb-5 italic">
            More details to come...
        </div> 

    </div>  

</template>