	
<script setup>

    const appStore   							= useAppStore()
    const { sideBarHidden, showBreakpoints }	= storeToRefs(appStore)

    // Keyboard Listeners & AutoRefreshAuth  ========================================================

    const keys = function (e)   
    {
        if (e.code === 'Escape'){ sideBarHidden.value = !sideBarHidden.value; e.preventDefault(); } 
    }

	KeyboardListeners(keys)		// Sets Key listeners for all pages using this layout
	AutoRefreshAuth()			// Refreshes JWT Tokens
	SetHtmlHeadBody() 			// Sets CSS 'theme' or 'alt-theme' for this layout

</script>

<template>

	<div id="layout-main">

		<div id="background-div" 
			class="fixed top-0 bottom-0 left-0 right-0 bg-gradient-back">
		</div>

		<div class="main-width mb-10 relative z-0 h-full">

			<BreakPoints :show="showBreakpoints" />
			
			<BrandBar class="flex justify-between items-center px-4 pr-5 md:ml-3 shadow-theme-layout">
				<UserPopout />
				<BrandLogo />
			</BrandBar>

			<NavBarMain class="shadow-theme-layout" />

			<div class="relative min-h-[600px] bg-white shadow-theme-layout border-r border-slate-200">
				<slot></slot>
			</div>
			
			<FooterBox class="shadow-theme-layout" />
			
		</div>

	</div> 

</template> 

	
<style lang="postcss" scoped>

	.active-tab .icon-symbol { @apply text-orange hover:text-black }
	
</style>
