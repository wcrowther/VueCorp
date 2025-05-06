<script setup>

    const homeTitle     = ref("Welcome to VueCorp Starter Solution")
    const appStore      = useAppStore()


</script>

<template>

    <div class="p-5 pt-5 sm:p-10 sm:pt-5 pb-14 grow 
        leading-relaxed h-full min-h-[600px] bg-gradient-main">

        <div class="flex flex-wrap gap-5 mb-7" id="HomeView">
            <div class="w-full flex justify-between items-center">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ homeTitle }}</h2>
                <span class="flex flex-wrap gap-1.5"> 
                    <!-- <button  class="btn-primary" @click="confirmSave">Save</button> -->
                </span>
            </div>
        </div> 

        <div class="flex flex-wrap mb-5 gap-y-5">

            <div class="pr-5 w-2/3 grow">
                <p class="pb-3 text-lg">
                    <b>VueCorp</b> is an open source project to promote using <b>Vue.js</b> with a
                    <b>DotNet</b> backend to create a simple yet powerful application environment. 
                    We started with the Microsoft's <b>Vue and Asp.Net Core</b> template which includes
                    a solution containing a <b>VueJs .esproj project</b> built using <b>Vite</b> for client 
                    the <b>SPA</b> project and a separate <b>C# DotNet Minimal API .csproj</b> for the backend 
                    that is integrated so that it can be built and published with a <b>single click</b>.
                </p> 
            </div>

            <div class="w-full md:w-1/3 grow italic p-5 min-w-[200px] flex flex-wrap gap-y-3
                border border-color-light-blue md:border-0 bg-gradient-source">

                <div class="w-full sm:w-1/2 md:w-full h-fit">
                    <div class="">View the customized DotNet c#:</div>
                    <a class="block font-bold link-underline text-blue break-words lg:break-normal"
                        :href="appStore.apiDocsUrl">
                        VueCorp API Documentation
                    </a>
                </div>

                <div class="w-full sm:w-1/2 md:w-full h-fit text-left sm:text-right md:text-left">
                    <div>The source for VueCorp is at: </div>
                    <a class="block font-bold link-underline text-blue break-all lg:break-normal"
                        href="https://github.com/wcrowther/VueCorp" target="_blank">
                        https://github.com/wcrowther/VueCorp
                    </a>
                </div>

            </div>

            <div class="pr-5 w-full grow">
                <p class="pb-3">    
                    Then we added real-world examples that show you how to integrate client side Pinia stores 
                    utilizing <b>JWT tokens</b> for api security to fetch data from your DotNet backend. The client 
                    project includes a page-based routing system and has auto-import component dependencies.
                </p>
                <p class="pb-3">
                    Our idea is not to focus on utilizing 3rd party component libraries to solve problems 
                    but rather to show you how to build simple but powerful components that allow you 
                    to embed your <b>'code intent'</b> and modify them as you need. The project is not meant to 
                    be 'the best' way to build an application - just a good example that you can start with.
                </p>
                <p class="pb-3">
                    We include a number of innovative ways to do things both in the <b>VueJs</b> and <b>DotNet</b> 
                    Minimal Api projects and are interested in outside contributions and suggestions moving forward. 

                </p>
                <p class="pb-3 font-bold">
                    Both VueJs and DotNet are wonderful technologies that 
                    are modern, streamlined, and fun to work with. 
                </p>
            </div>

             <!-- <HomeView2 />Still working on -->
            
        </div>

    </div>  

</template>