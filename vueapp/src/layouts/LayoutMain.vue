	
<script setup>

    const appStore     			= useAppStore()
    const {  sideBarHidden, showBreakpoints, altColors } 	
								= storeToRefs(appStore)
	const authStore     		= useAuthStore()
    const { authUser } 			= storeToRefs(authStore)

    // Keyboard Listeners  =====================================================================

    const keys = function (e)   
    {
        if (e.code === 'Escape'){ sideBarHidden.value = !sideBarHidden.value; e.preventDefault(); } 
    }

	KeyboardListeners(keys);

</script>

<template>

	<div class="fixed top-0 bottom-0 left-0 right-0" id="background-div"
		:class="{'bg-gradient-back': !altColors}"></div>

	<div class="main-width mb-10 relative z-0" id="layout-main"
		:class="{ '' : altColors }"><!-- box-shadow -->

		<BreakPoints :show="showBreakpoints" />

		<BrandBar class="flex justify-between items-center px-4 pr-5">
			<LoginPopout />
			<BrandLogo />
		</BrandBar>  

		<NavBar class="" id="nav-bar">		
			<NavTab to="/" class="group" >
				<IconSymbol width="18px" class="mt-[8px] xs:mt-[10px] text-color-dark-gray
					group-hover:text-white group-hover:opacity-100" icon="heroicons-solid:home" />
			</NavTab>
			<NavTab navText="Content" 	to="/content" />
			<NavTab navText="Accounts" 	to="/accounts" />
			<NavTab navText="Admin" 	to="/admin"  v-if="authUser.Role == 'Admin'" />
		</NavBar>

		<div class="relative h-full min-h-[600px] bg-white" id="mainContent"> 
			<slot></slot>
		</div>

		<FooterBox />

	</div> 

</template> 
	
<style lang="postcss" scoped>

	.box-shadow { @apply shadow-[-14px_14px_18px_0px_rgba(97,97,97,0.75)] shadow-color-mid-gray }    
	.active-tab .icon-symbol { @apply text-orange hover:text-black }

</style>
