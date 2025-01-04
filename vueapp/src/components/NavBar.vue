<script setup></script>

<template>
    <div class="pl-3 pr-5 sm:pr-10 h-12 flex gap-x-1 justify-end items-end select-none navbar-gradient">
        <slot></slot>
    </div>
</template>

<style lang="postcss" scoped>
	.navbar-gradient { @apply bg-[linear-gradient(58deg,#577fa8_4%,#1c2157_50%)]  } 
</style>



