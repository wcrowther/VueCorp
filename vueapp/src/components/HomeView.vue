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
                    <!-- <button  class="btn-primary" @click="confirmSave">Save</button> -->
                </span>
            </div>
        </div> 

        <div class="flex flex-wrap mb-5 gap-y-5">

            <div class="pr-5 w-2/3 grow">
                <p class="pb-3 text-lg">
                    <b>VueCorp</b> is an open source project to promote using <b>VueJs</b> with 
                    <b>DotNet</b> backend technologies to create a simple yet powerful application environment. 
                    We started with the Microsoft's <b>Vue and Asp.Net Core</b> template that has a 
                    solution that includes a <b>VueJs .esproj</b> built using <b>Vite</b> for client 
                    the <b>SPA</b> project and a separate <b>C# DotNet Minimal API .proj</b> for the backend 
                    that is integrated so that it can be built and published with a <b>single click</b>.
                </p> 
            </div>

            <div class="w-full md:w-1/3 grow italic p-3 min-w-[200px] 
                border border-color-light-blue md:border-0 bg-gradient-source">
                
                <span>The source for VueCorp is at: </span>
                <a class="inline font-bold link-underline text-blue break-words lg:break-normal" 
                    href="https://github.com/wcrowther/VueCorp" target="_blank">
                    https://github.com/wcrowther/VueCorp
                </a>

            </div>

            <div class="pr-5 w-full grow">
                <p class="pb-3">
                    We started with the Microsoft's <b>Vue and Asp.Net Core</b> template that has a 
                    solution that includes a <b>VueJs .esproj</b> built using Vite for the client SPA project and a
                    separate C# DotNet Minimal API .proj for the backend that is integrated so that it
                    can be built and published with a single click.
                </p>
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

            <!-- Still working on <HomeView2 /> -->
            
        </div>

    </div>  

</template>