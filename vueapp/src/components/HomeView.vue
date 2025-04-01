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
                    VueCorp is an open source project to promote using VueJs 3.5 
                    for the frontend client combined with a DotNet Minimal API backend as a
                    powerful web application with a streamlined modern web development experience.
                </p> 
            </div>

            <div class="w-full md:w-1/3 grow italic p-3 min-w-[200px] bg-gradient-source">
                <span>The source for VueCorp is at: </span>
                <a class="inline font-bold link-underline text-blue break-words lg:break-normal" 
                    href="https://github.com/wcrowther/VueCorp" target="_blank">
                    https://github.com/wcrowther/VueCorp
                </a>
            </div>

            <div class="pr-5 w-full grow">
                <p class="pb-3">
                    We started with the Microsoft 'Vue and Asp.Net Core' template that supplies a solution
                    that includes a VueJs .esproj built using Vite for the client SPA project and a
                    separate C# DotNet Minimal API .proj for the backend that is integrated so that it
                    can be built and published with a single click.
                </p>
                <p class="pb-3">    
                    We provide real-world examples that show you how to integrate client side Pinia stores 
                    utilizing JWT tokens for api security to fetch data from your DotNet backend. The client 
                    project includes a page-based routing system and has auto-import component dependencies.
                </p>
                <p class="pb-3">
                    Our idea is not to focus on utilizing 3rd party component libraries to solve problems 
                    but rather to show you how to build simple but powerful components that allow you 
                    to embed your 'code intent' and modify them as you need. The project is not meant to 
                    be 'the best' way to build an application just a good example that you can start with.
                </p>
                <p class="pb-3">
                    We include a number of innovative ways to do things both in the VueJs and DotNet 
                    Minimal Api projects (see below) and are interested in outside contributions and 
                    suggestions moving forward. Both VueJs and DotNet are wonderful technologies that 
                    are modern, streamlined, and fun to work with. 
                </p>
                <p class="pb-3 font-bold">
                    Let's build!
                </p>
            </div>

            <h3 class="font-bold text-base">Vue / DotNet Corp Template</h3>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                quisquam consequatur libero. Fuga blanditiis quo iure qui reprehenderit eos,
                eaque expedita dolorem tempora praesentium veritatis distinctio sit recusandae?
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                quisquam consequatur libero. Fuga blanditiis quo iure qui reprehenderit eos,
                eaque expedita dolorem tempora praesentium veritatis distinctio sit recusandae?
            </p>
            <h4 class="font-bold">Features</h4>
            <ol class="w-full">
                <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                    quisquam consequatur libero.
                </li>
                <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                    quisquam consequatur libero.
                </li>
                <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                    quisquam consequatur libero.
                </li>
                <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                    quisquam consequatur libero.
                </li>
            </ol>

            <div class="flex flex-wrap gap-y-5 bg-[#e9f3fa] p-10 -mx-10">
                <h3 class="font-bold text-base">Vue 3.5 Client App with Composition Api / Vite / Pinia</h3>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                    quisquam consequatur libero. Fuga blanditiis quo iure qui reprehenderit eos,
                    eaque expedita dolorem tempora praesentium veritatis distinctio sit recusandae?
                </p>
                <h4 class="font-bold">Features</h4>
                <ol class="w-full">
                    <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                        quisquam consequatur libero.
                    </li>
                    <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                        quisquam consequatur libero.
                    </li>
                    <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                        quisquam consequatur libero.
                    </li>
                    <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                        quisquam consequatur libero.
                    </li>
                    <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                        quisquam consequatur libero.
                    </li>
                    <li class="list-inside list-decimal mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                        quisquam consequatur libero.
                    </li>
                </ol>
            </div>

            <h3 class="font-bold text-base clear-both">DotNet Minimal Api Server Backend</h3>
            <p>
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at 
                quisquam consequatur libero. Fuga blanditiis quo iure qui reprehenderit eos, 
                eaque expedita dolorem tempora praesentium veritatis distinctio sit recusandae?
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at 
                quisquam consequatur libero. 
            </p>  
            <h4 class="font-bold">Features</h4>
            <ol class="w-full">               
                <li class="list-inside list-decimal mb-3">
                    Uses .NET role-based user Authentication with JWT tokens passed for API authentication.
                </li>
                <li class="list-inside list-decimal mb-3">
                    Custom Minimal API model validation using propery attributes
                </li>
                <li class="list-inside list-decimal mb-3">
                    File-based logging of events using ILogger with Serilog
                </li>
                <li class="list-inside list-decimal mb-3">
                    Simple convention-based registration of endpoints
                </li>
                <li class="list-inside list-decimal mb-3">
                    Service registration moved to an external file to simplify Program.cs
                </li>
                <li class="list-inside list-decimal mb-3">
                    Swagger endpoints documentation with authorization and look-and-feel customization
                </li>
                <li class="list-inside list-decimal mb-3">
                    Configuration of user-specified CORS origins
                </li>
            </ol>        
        </div>

    </div>  

</template>