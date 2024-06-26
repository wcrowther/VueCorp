	
<script setup>

    const appStore     		= useAppStore()
    const 
	{ 
		sideBarHidden,
		showBreakpoints,
		altColors
	} 						= storeToRefs(appStore)

	const authStore     	= useAuthStore()
    const { authUser } 		= storeToRefs(authStore)

    // Listeners   =============================================================================

    const keys = function (e)   
    {
        if (e.code === 'Escape')       { sideBarHidden.value = !sideBarHidden.value; e.preventDefault(); } 
    }

    const addKeyListeners       = () => document.addEventListener('keydown', keys, false)
    const removeKeyListeners    = () => document.removeEventListener('keydown', keys, false)

    onMounted(()    =>  addKeyListeners() )
    onUnmounted(()  =>  removeKeyListeners() )

	// =========================================================================================

</script>

<template>

	<div class="fixed top-0 bottom-0 left-0 right-0" id="background-div"
		:class="{'bg-gradient-back': !altColors}"></div>

	<div class="main-width mb-10 relative z-0" id="layout-main"
		:class="{ 'box-shadow' : altColors }">

		<BreakPoints :show="showBreakpoints" />

		<BrandBar class="flex justify-between items-center px-4 pr-5">
			<LoginPopout />
			<BrandLogo />
		</BrandBar>  

		<NavBar class="" id="nav-bar">		
			<NavTab navText="Home" 		to="/" />
			<NavTab navText="Accounts" 	to="/accounts" />
			<NavTab navText="Admin" 	to="/admin"  v-if="authUser.Role != 'User'" />
		</NavBar>

		<div class="relative h-full min-h-[600px] bg-white" id="mainContent"> 
			<slot></slot>
		</div>

		<FooterBox />

	</div> 

</template> 
	
<style lang="postcss" scoped>

	.box-shadow {
		@apply shadow-[-14px_14px_18px_0px_rgba(97,97,97,0.75)] shadow-color-mid-gray
	}    
	
</style>
