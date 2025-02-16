<script setup>
    //const appStore     		= useAppStore()
    //const { altColors } 	= storeToRefs(appStore)
</script>

<template>
	<router-link class="mr-6 block h-[18px] w-[100px] bg-brand-logo bg-contain bg-no-repeat leading-loose
		bg-center font-serif text-white text-xl/10 align-middle text-right relative" 		
        to='/' title="Homepage / Logo">
	</router-link> 
</template>

<style lang="postcss" scoped>

	.alt{ @apply text-black }    
	.adjust-logo {
		@apply m-auto xs:mr-0 text-center
	}
	
</style>


<!--  :class="{ 'alt': altColors , 'adjust-logo': appStore.showPrevNext}" -->