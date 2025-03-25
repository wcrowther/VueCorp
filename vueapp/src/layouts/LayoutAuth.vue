	
<script setup>

    const appStore     		= useAppStore()
    const { altTheme }		= storeToRefs(appStore)

</script>

<template>

	<!-- Adding theme here cascades down to the whole page  -->	
	<div class="h-full" :class="[altTheme ? 'alt-theme': 'theme']">

		<div id="background-div" 
			class="fixed top-0 bottom-0 left-0 right-0 bg-gradient-back">
		</div>

		<div id="layout-login"
			class="relative z-0 h-full w-[380px] sm:w-[560px] mt-10 mx-auto" >


			<BrandBar class="shadow-theme-layout pr-5 md:mx-3">
				<BrandLogo />
			</BrandBar>  

			<div class="shadow-theme-layout border-r border-gray-200">
				<slot></slot>
			</div>	

			<FooterBox class="shadow-theme-layout" />

		</div>	

	</div>

</template> 
	
<style lang="postcss" scoped>

	.box-shadow {
		@apply shadow-[-14px_14px_18px_0px_rgba(97,97,97,0.75)] shadow-color-mid-gray
	}  

</style>
	
