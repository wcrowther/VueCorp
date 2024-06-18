<script setup>
    const appStore     		= useAppStore()
    const { altColors } 	= storeToRefs(appStore)
</script>

<template>
	<router-link class="block h-10 w-[130px] bg-contain bg-no-repeat bg-brand-logo leading-loose
		bg-center font-serif text-white text-xl/10 align-middle text-right relative -left-3 xs:left-0" 		
        :class="{ 'alt': altColors }" to='/' title="Homepage / Logo">VueCorp
	</router-link> 
</template>

<style lang="postcss" scoped>

	.alt{ @apply text-black }    
	
</style>