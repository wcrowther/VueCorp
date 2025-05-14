<script setup>

    const homeTitle     = ref("Welcome to VueCorp Starter Solution")
    const appStore      = useAppStore()

</script>

<template>

    <div class="p-5 pt-5 sm:p-10 sm:pt-5 grow leading-relaxed h-full 
        bg-gradient-main border-b border-color-light-blue">

        <div class="flex flex-wrap gap-5 mb-7" id="HomeView">
            <div class="w-full flex justify-between items-center">
                <h2 class="text-2xl font-display font-bold flex-grow">{{ homeTitle }}</h2>
                <span class="flex flex-wrap gap-1.5"> 
                    <!-- <button  class="btn-primary" @click="confirmSave">Save</button> -->
                </span>
            </div>
        </div> 

        <div class="flex flex-wrap gap-y-5">

            <div class="pr-5 w-2/3 grow">
                <p class="pb-3 text-lg">
                    <b>VueCorp</b> is an open source project to promote using <b>Vue.js</b> with a
                    <b>DotNet</b> backend to create a simple yet powerful application environment. 
                    We combined a <b>VueJs </b> SPA project (.esproj) built using <b>Vite</b> with a 
                    separate <b>.Net Minimal API </b> project for the backend that is 
                    integrated so that it can be built into a single deployment 
                    with a simple Visual Studio <b>Publish</b>.
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
                    We've included real-world examples demonstrating how to integrate client-side <b>Pinia</b> stores using 
                    <b>JWT tokens</b> for secure API access to your .NET backend. The client project features page-based 
                    routing and automatic component dependency imports.
                </p>
                <p class="pb-3">
                    Rather than relying on third-party UI libraries, we focus on building clean, powerful components that 
                    reflect your <b>code intent</b> and are easy to adapt. This project isn’t meant to be the definitive 
                    way to build an app — just a solid starting point.
                </p>
                <p class="pb-3">
                    You'll find a number of innovative techniques throughout both the <b>Vue.js</b> and <b>.NET</b> 
                    Minimal API projects. We welcome contributions and suggestions as the project evolves.
                </p>
            </div>
        </div>

    </div>  

</template>