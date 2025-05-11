<script setup></script>

<template>

    <div class="flex flex-wrap gap-y-5 bg-white/50 p-10 -mx-10">
        <h3 class="font-bold text-base">Vue / DotNet Combined Solution</h3>
        <p>
            The VueCorp solution is structured to establish a clear separation of concerns by isolating 
            the frontend (Vue) and backend (Asp.net Minimal Api) into distinct projects. Despite this separation, 
            the template integrates the build and publish processes so that both layers can be compiled and deployed 
            as a single web application, simplifying hosting while maintaining a modular architecture.
        </p>
        <h4 class="font-bold">Features</h4>
        <ol class="w-full list-decimal pl-10"> 
            <li class="mb-3">You can run both projects in Visual Studio 2022 using a normal 
                Start command that deploys both. Alternately, you can elect to edit the C# project in VS 2022 and 
                use VSCode for the Vuejs project, launching them separately.
            </li>
            <li class="mb-3">When you deploy the C# Asp.net project using the Visual Studio 2022 <b>Publish</b> feature, 
                the Vuejs project is built and deployed as a single web site. 
            </li>
            <li class="mb-3">The C# deploys a Swagger API documentation page that lists all to endpoints 
                and how to call them. This can be configured to not display in Production.                 
            </li>
        </ol>
    </div>

    <div class="flex flex-wrap gap-y-5 bg-[#e9f3fa] p-10 -mx-10 border">
        <h3 class="font-bold text-base">Vue.js 3.5 Client App with Composition Api / Vite / Pinia</h3>
        <p>
            The 
        </p>
        <h4 class="font-bold">Features</h4>
        <ol class="w-full list-decimal pl-10"> 
            <li class="mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                quisquam consequatur libero.
            </li>
            <li class="mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                quisquam consequatur libero.
            </li>
            <li class="mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                quisquam consequatur libero.
            </li>
            <li class="mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                quisquam consequatur libero.
            </li>
            <li class="mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                quisquam consequatur libero.
            </li>
            <li class="mb-3">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sapiente dolores at
                quisquam consequatur libero.
            </li>
        </ol>
    </div>
    <div class="flex flex-wrap gap-y-5 bg-white p-10 -mx-10">
        <h3 class="font-bold text-base clear-both">DotNet Minimal Api Server Backend</h3>
        <p>
            The example c# Asp.net Minimal API  project is built with simple but powerful examples of
            features that can used to get you started building out your own project.
        </p>  
        <h4 class="font-bold border">Features</h4>
        <ol class="w-full list-decimal pl-10"> 
            <li class="mb-3">
                Uses Entity Framework accessing a SQLite database but should be easy to convert to another 
                database like SQL server or MySQL.
            </li>              
            <li class="mb-3">
                .NET role-based user Authentication with JWT tokens passed in for API authentication for the 
                Vuejs web requests. This is all backed by an example editable User table.
            </li>
           <li class="mb-3">
                Custom PagedList examples for an example Account entity using Linqkit PredicateBuilder making 
                it easy to customize and add in multiple search conditions.
            </li>
            <li class="mb-3">
                Custom Minimal API model validation using property attributes.
            </li>
            <li class="mb-3">
                File-based logging of events using ILogger with Serilog.
            </li>
            <li class="mb-3">
                Works with a custom simple convention-based registration of endpoints to declutter your Program.cs file.
            </li>
            <li class="mb-3">
                Service registration moved to an external file to simplify your Program.cs.
            </li>
            <li class="mb-3">
                Swagger endpoints documentation with authorization and look-and-feel customization.
            </li>
            <li class="mb-3">
                Allows for simple configuration of user-specified CORS origins.
            </li>
        </ol> 
    </div>
</template>