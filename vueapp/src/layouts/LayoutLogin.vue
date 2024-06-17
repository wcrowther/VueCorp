	
<script setup>

    const currentYear 		= new Date().getFullYear()
    const appStore     		= useAppStore()
    const { altColors }		= storeToRefs(appStore)

</script>

<template>

	<div class="fixed top-0 bottom-0 left-0 right-0" :class="{'bg-gradient-back': !altColors}" id="background-div"></div>

	<div class="relative z-0 h-full w-[380px] sm:w-[560px] mt-10 mx-auto" id="layout-login">
		<slot></slot>

		<div class="flex justify-center">
			<div class="mt-10 text-sm text-color-primary m-auto">&copy; {{currentYear}} Will Crowther</div>
		</div>
	</div>

</template> 
	
<style lang="postcss" scoped></style>
	
