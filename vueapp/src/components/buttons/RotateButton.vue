<script setup>

	const modelValue = defineModel()

</script>

<template>
	<span class="block transition duration-300" :class="{ 'rotate-90' : modelValue }"
		title="props.title" @click="modelValue = !modelValue">
		<IconSymbol width="26px" class="text-color-dark-gray hover:text-color-mid-gray" icon="heroicons:bars-4" />
	</span> 
</template>
