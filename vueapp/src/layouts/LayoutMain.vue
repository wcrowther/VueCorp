	
<script setup>

    const appStore        		= useAppStore()
    const { sideBarHidden,
		showBreakpoints } 		= storeToRefs(appStore)

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

	<div id="layout-main" class="relative z-0">

		<BreakPoints :show="showBreakpoints" />

		<BrandBar class="main-width flex justify-between items-center px-5 ">
			<LoginPopout />
			<router-link class="block h-10 w-[130px] bg-contain bg-no-repeat bg-brand-log leading-loose
				bg-center font-serif text-white text-xl/10 align-middle text-right relative -left-3 xs:left-0" 
				to='/' title="Homepage / Logo">VueCorp
			</router-link> 
		</BrandBar>  

		<NavBar class="main-width">		
			<NavTab navText="Home" 		to="/" />
			<NavTab navText="Accounts" 	to="/accounts" />
			<NavTab navText="Admin" 	to="/admin" />
		</NavBar>

		<div id="mainContent" class="main-width relative h-full min-h-[600px] bg-white"> <!-- bg-gradient-main -->
			<slot></slot>
		</div>

	</div> 
	
	<FooterBox />

</template> 
	



<!-- 
<router-link class="nav-tab" active-class="active-tab" to="/">
	<span class="">Home</span>
	<ReverseCorner :pixelSize="7" class="hidden bottom-0 left-[-7px]" />
    <ReverseCorner :pixelSize="7" class="hidden bottom-0 right-[-7px] rotate-90" />	
</router-link>

<style lang="postcss" scoped>

	.nav-tab {
		@apply text-[#121639] font-semibold font-sans text-base/9 rounded-t-md list-none h-8 px-3
		flex relative bg-color-light-blue hover:bg-transparent hover:text-white opacity-80
	}    
	.active-tab {
		@apply text-orange hover:text-black bg-gradient-tab-active opacity-100
	}
	.active-tab .corner {
		@apply block
	}
	
</style>
-->