	
<script setup>

    const appStore     			= useAppStore()
	const authStore     		= useAuthStore()

    const { sideBarHidden, showBreakpoints, altColors }	= storeToRefs(appStore)
    const { authUser  } 								= storeToRefs(authStore)

    // Keyboard Listeners & AutoRefreshToken  ========================================================

    const keys = function (e)   
    {
        if (e.code === 'Escape'){ sideBarHidden.value = !sideBarHidden.value; e.preventDefault(); } 
    }

	KeyboardListeners(keys)

	AutoRefreshToken()	

</script>

<template>

	<div id="background-div" class="fixed top-0 bottom-0 left-0 right-0" 
		:class="{'bg-gradient-back': !altColors}"></div>

	<div id="layout-main" class="main-width mb-10 relative z-0" 
		:class="{ '' : altColors }"><!-- box-shadow -->

		<BreakPoints :show="showBreakpoints" />

		<BrandBar class="flex justify-between items-center px-4 pr-5 md:ml-3">
			<LoginPopout />
			<BrandLogo />
		</BrandBar>  

		<NavBar id="nav-bar" class="navbar-gradient">

			<NavTab to="/" class="group">
				<IconSymbol width="18px" class="text-[#121639] block xs:hidden 
					group-hover:text-white group-hover:opacity-100" icon="heroicons-solid:home" />
				<span class="hidden xs:block">Home</span>
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
	.navbar-gradient { @apply bg-[linear-gradient(90deg,#7ab7d8_2%,#1c2157_50%)] md:ml-3 } 

</style>
