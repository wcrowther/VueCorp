	
<script setup>

    const appStore     			= useAppStore()

    const { sideBarHidden, showBreakpoints, altColors }	= storeToRefs(appStore)

    // Keyboard Listeners & AutoRefreshAuth  ========================================================

    const keys = function (e)   
    {
        if (e.code === 'Escape'){ sideBarHidden.value = !sideBarHidden.value; e.preventDefault(); } 
    }

	KeyboardListeners(keys)

	AutoRefreshAuth()	

</script>

<template>

	<div class="h-full">

		<div id="background-div" class="fixed top-0 bottom-0 left-0 right-0"
			:class="{'bg-gradient-back': !altColors}"></div>

		<div id="layout-main" class="main-width mb-10 relative z-0 h-full"
			:class="{ '' : altColors }"><!-- box-shadow -->

			<BreakPoints :show="showBreakpoints" />
			
			<BrandBar class="flex justify-between items-center px-4 pr-5 md:ml-3">
				<LoginPopout />
				<BrandLogo />
			</BrandBar>

			<NavBarMain />

			<div class="relative h-full min-h-[600px] bg-white" id="mainContent">
				<slot></slot>
			</div>
			
			<FooterBox />
		</div>

	</div> 

</template> 
	
<style lang="postcss" scoped>

	.box-shadow { @apply shadow-[-14px_14px_18px_0px_rgba(97,97,97,0.75)] shadow-color-mid-gray }    
	.active-tab .icon-symbol { @apply text-orange hover:text-black }
	.navbar-gradient { @apply bg-[linear-gradient(90deg,#7ab7d8_2%,#1c2157_50%)] md:ml-3 } 

</style>
