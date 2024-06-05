	
<script setup>

    const currentYear = new Date().getFullYear()

</script>

<template>

	<div id="layout-login" class="relative z-0 h-full w-[380px] sm:w-[560px] mt-10 mx-auto">
		<slot></slot>

		<div class="flex justify-center">
			<div class="mt-10 text-sm text-color-primary m-auto">&copy; {{currentYear}} Will Crowther</div>
		</div>
	</div>

</template> 
	
<style lang="postcss" scoped></style>
	
