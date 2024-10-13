<script setup>
    const appStore     		= useAppStore()
    const { altColors } 	= storeToRefs(appStore)
</script>

<template>
	<router-link class="block h-10 w-[130px] bg-contain bg-no-repeat bg-brand-logo leading-loose
		bg-center font-serif text-white text-xl/10 align-middle text-right relative" 		
        :class="{ 'alt': altColors , 'adjust-logo': appStore.showPrevNext}" to='/' title="Homepage / Logo">VueCorp
	</router-link> 
</template>

<style lang="postcss" scoped>

	.alt{ @apply text-black }    
	.adjust-logo {
		@apply m-auto xs:mr-0 
	}
	
</style>