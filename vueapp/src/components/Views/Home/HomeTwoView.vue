<script setup></script>

<template>

    <div class="pb-5">
    
        <div class="flex flex-wrap gap-y-3 bg-white/50 p-10">

            <h3 class="font-bold text-lg">Vue / Asp.net Combined Solution</h3>

            <p class="w-full">
                The VueCorp solution is structured to establish a clear separation of concerns by isolating
                the frontend (Vue) and backend (Asp.net Minimal Api) into distinct projects. Despite this separation,
                the template integrates the build and publish processes so that both layers can be compiled and deployed
                as a single web application, simplifying hosting while maintaining a modular architecture.
            </p>

            <h4 class="text-base font-bold tracking-wide">Features</h4>

            <ol class="ol-list">
                <li>
                    <span>One-Click Deploy</span>
                    You can run both projects in <b>Visual Studio 2022</b> using a normal
                    <b>Start</b> command that deploys both projects to a single web site.
                </li>
                <li>
                    <span>Multiple Deploy</span>
                    Alternately, you can elect to edit the C# project in <b>Visual Studio 2022</b> and
                    use <b>VSCode</b> for the <b>Vuejs</b> project, launching them separately for debugging 
                    but combined into a single site for production.
                </li>
                <li>
                    <span>EZ Publish</span>
                    Deploy the C# Asp.net project using the Visual Studio 2022 <b>Publish</b> feature
                    and the Vuejs project is built and deployed as a single web site.
                </li>
                <li>
                    <span>API Documentation</span> 
                    The C# code deploys a Swagger API documentation page that lists all the endpoints
                    and how to call them. This can be configured to not display in Production.
                </li>
            </ol>

        </div>
    
        <div class="flex flex-wrap gap-y-5 bg-[#e9f3fa] p-10">

            <h3 class="font-bold text-lg">Vue.js App w/ Vite & Pinia</h3>
           
           <p class="w-full">
                The Vue.js 3.5 project uses the Composition Api with Vite to build and Pinia as a
                data store. To minimize boilerplate, we use Unplugin for page-based routing, auto-configure Vue imports,
                and your auto-import your custom components. Rather than use a UI import library we build
                simple reusable components for things like list pagers, toasts, modals, form inputs, etc,
                to reduce outside dependencies.
            </p>

            <h4 class="text-base font-bold tracking-wide">Features</h4>

            <ol class="ol-list">
                <li>
                    <span>Vite</span>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorem necessitatibus non 
                </li>
                <li>
                    <span>Page-based Routing</span>Uses page-based routing with 'unplugin-vue-router' that auto configures
                    Vue Router based on the hierarchy of the src/Pages folder.
                </li>
                <li>
                    <span>Removing Boilerplate Code</span>
                    We use 'unplugin-vue-components' and 'unplugin-auto-import' to remove
                    boilerplate code by auto-importing vue and custom components on demand  leaving
                    the code to more succinctly express the logic.
                </li>
                <li>
                    <span>Custom Components</span>
                    Our custom components are simple
                </li>
                <li>
                    <span>TailwindCss</span>
                     ... themes
                </li>
                <li>
                    <span>List Pager w/ Debugger</span>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorem necessitatibus non
                </li>
                <li>
                    <span>Fluid mobile / web</span>
                    w/ collapsible menu area
                </li>
                <li>
                    <span>Search / Advanced Search</span>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorem necessitatibus non
                </li>
                <li>
                    <span>Keyboard Shortcuts</span>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorem necessitatibus non
                </li>
                <li>
                    <span>Custom API</span>
                    access with built in toast message /  JWT tokens
                </li>
                <li>
                    <span>Pinia datastores</span>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorem necessitatibus non
                </li>
                <li>
                    <span>Local Storage</span>
                    Client user configuration using local storage
                </li>
                <li>
                    <span>Model Validation w/ Vuelidate</span>
                    Simple integrated model validation with Vuelidate
                </li>
                <li>
                    <span>VueUse</span>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorem necessitatibus non
                </li>
            </ol>

        </div>
    
        <div class="flex flex-wrap gap-y-5 bg-white p-10">      

            <h3 class="font-bold text-lg">DotNet Minimal Api Server Backend</h3>

            <p class="w-full">
                The c# Asp.net Minimal API  project is built with simple but powerful examples of
                features that can used to get you started building out your own project.
            </p>

            <h4 class="text-base font-bold tracking-wide">Features</h4>

            <ol class="ol-list">
                <li>
                    <span>SQLite</span>
                    We use Entity Framework accessing a SQLite database but should be
                    easy to convert to another database like SQL server or MySQL.
                </li>
                <li>
                    <span>JWT Tokens</span>
                    Role-based user authentication using JWT tokens in .NET for securing Vue.js API 
                    requests, backed by an editable user table.
                </li>
               <li>
                    <span>PagedList</span>
                    Custom PagedList examples for an example Account entity using Linqkit PredicateBuilder making
                    it easy to customize and add in multiple search conditions.
                </li>
                <li>
                    <span>Attribute Validation</span>
                    Our custom Minimal API model validation uses a simple validation routine to evaluate
                    server model property attributes (this is not available in .NET 9).
                </li>
                <li>
                    <span>Server Event Logging</span>
                    File-based logging of events using ILogger with Serilog.
                </li>
                <li>
                    <span>Endpoint Registration</span>
                    Works with a custom simple convention-based registration of endpoints to declutter your Program.cs file.
                </li>
                <li>
                    <span>DI Registration</span>
                    Service registration moved to an external file to simplify your Program.cs.
                </li>
                <li>
                    <span>API Documentation</span>
                    Out of the box Swagger endpoints documentation with authorization and
                    look-and-feel customization.
                </li>
                <li>
                    <span>CORS</span>
                    Allows for simple configuration of user-specified CORS origins.
                </li>
            </ol>

        </div>

    </div>

</template>

<style lang="postcss" scoped>

    .ol-list                { @apply w-full list-decimal pl-8 }
    .ol-list li             { @apply mb-3 }
    .ol-list li span        { @apply text-base font-bold mr-1 text-color-dark-blue }
    .ol-list li span:after  { content: '\00a0 \00a0- ' }

</style>