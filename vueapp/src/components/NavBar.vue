<script setup></script>

<template>
    <div class="main-width pl-3 pr-5 sm:pr-10 h-10 flex gap-x-1 justify-end items-end select-none navbar-gradient">
        <slot></slot>
    </div>
</template>

<style lang="postcss" scoped>
	.navbar-gradient {
        background-image: linear-gradient( 58deg, #577fa8 4%, #1c2157 50%) 
    }    
</style>

<!--

    linear-gradient( 58deg, #577fa8 4%, #1c2157 50%);

<style lang="postcss" scoped>
	.navbar-gradient {
         @apply bg-gradient-to-r from-indigo-500 from-10% via-sky-500 via-30% to-emerald-500 to-90%   
    }    
</style>
-->
	


