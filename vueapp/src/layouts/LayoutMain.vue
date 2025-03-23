	
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
				<UserPopout />
				<BrandLogo />
			</BrandBar>

			<NavBarMain />

			<div :class="['relative h-full min-h-[600px] bg-white', altColors ? 'shadow-[-5px_5px_5px_0px_rgba(195,195,195,0.5)]' : '' ]">
				<slot></slot>
			</div>
			
			<FooterBox />
		</div>

	</div> 

</template> 
	
<style lang="postcss" scoped>

	.active-tab .icon-symbol { @apply text-orange hover:text-black }
	
</style>
