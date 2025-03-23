<script setup>
    const appStore     		= useAppStore()
    const { altColors, showPrevNext } 	= storeToRefs(appStore)
</script>

<template>
	<router-link 
		:class="['h-[24px] w-[150px] bg-contain bg-no-repeat bg-center relative', 
		altColors ? 'bg-brand-logo-alt' : 'bg-brand-logo', 
		showPrevNext ? 'adjust-logo' : '']" 		
        to='/' title="Homepage / Logo">
	</router-link> 
</template>

<style lang="postcss" scoped>

	.adjust-logo {
		@apply m-auto xs:mr-0 text-center
	}
	
</style>
