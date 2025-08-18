	
<script setup>

    const appStore   							= useAppStore()
    const { sideBarHidden, layoutEscapeKeyOn }	= storeToRefs(appStore)

    // Keyboard Listeners & AutoRefreshAuth  ========================================================
    // --- Disable global Escape for layout by setting app.layoutEscapeKeyOn to false
    const keys = function (e)   
    {
		if (e.code === 'Escape' && layoutEscapeKeyOn.value){ sideBarHidden.value = !sideBarHidden.value; e.preventDefault(); } 
    }

	KeyboardListeners(keys)		// Sets Key listeners for all pages using this layout
	AutoRefreshAuth()			// Refreshes JWT Tokens
	SetHtmlHeadBody() 			// Sets CSS 'theme' or 'alt-theme' for this layout

	// onMounted(() => console.log('LayoutMain onMounted'))

</script>

<template>

	<div id="layout-main">

		<div id="background-div" 
			class="fixed top-0 bottom-0 left-0 right-0 bg-gradient-back">
		</div>

		<div class="mb-10 relative z-0 h-full">

			<BreakPoints />
			
			<BrandBar>
				<UserPopout />
				<BrandLogo />
			</BrandBar>

			<MainNavBar />

			<MainContent>
				<slot></slot>
			</MainContent>
			
			<FooterBox  />

			<NotificationControl /> 
			
		</div>

	</div> 

</template> 

	
<style lang="postcss" scoped>

	.active-tab .icon-symbol { @apply text-orange hover:text-black }
	
</style>
