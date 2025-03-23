<script setup>
    const appStore     		= useAppStore()
    const { showPrevNext } 	= storeToRefs(appStore)
</script>

<template>
	<router-link 
		:class="['h-[24px] w-[150px] bg-brand-logo bg-contain bg-no-repeat bg-center relative', 
		showPrevNext ? 'adjust-logo' : '']" 		
        to='/' title="Homepage / Logo">
	</router-link> 
</template>

<style lang="postcss" scoped>

	.adjust-logo {
		@apply m-auto xs:mr-0 text-center
	}
	
</style>
