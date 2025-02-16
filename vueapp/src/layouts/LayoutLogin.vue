	
<script setup>

    const appStore     		= useAppStore()
    const { altColors }		= storeToRefs(appStore)

</script>

<template>

	<div class="fixed top-0 bottom-0 left-0 right-0" 
		:class="{'bg-gradient-back': !altColors}" id="background-div"></div>

	<div class="relative z-0 h-full w-[380px] sm:w-[560px] mt-10 mx-auto" id="layout-login">

		<div :class="{ 'box-shadow' : altColors }">

			<BrandBar class="pr-5 md:mx-3">
				<BrandLogo />
			</BrandBar>  

			<slot></slot>	
			
			<FooterBox />
		</div>
	</div>

</template> 
	
<style lang="postcss" scoped>

	.box-shadow {
		@apply shadow-[-14px_14px_18px_0px_rgba(97,97,97,0.75)] shadow-color-mid-gray
	}  

</style>
	
