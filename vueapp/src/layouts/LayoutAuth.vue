	
<script setup>

    const appStore     		= useAppStore()
    const { altTheme }		= storeToRefs(appStore)

	SetHtmlHeadBody() 			// Sets CSS 'theme' or 'alt-theme' for this layout
	
</script>

<template>

	<!-- Adding theme here cascades down to the whole page  -->	
	<div id="layout-auth"
		class="h-full" :class="[altTheme ? 'alt-theme': 'theme']">

		<div id="background-div" 
			class="fixed top-0 bottom-0 left-0 right-0 bg-gradient-back">
		</div>

		<div class="relative z-0 h-full w-[390px] sm:w-[560px] mt-10 mx-auto" >

			<BrandBar class="pr-5 md:mx-3 shadow-theme-layout ">
				<BrandLogo />
			</BrandBar>  

			<div class="border-r border-gray-200 shadow-theme-layout ">
				<slot></slot>
			</div>	

			<FooterBox class="shadow-theme-layout" />

		</div>	

	</div>

</template> 