<script setup>

	const props = defineProps(
	{
		title: String
	})

</script>

<template>
    <button class="btn-primary">
		<slot>{{ props.title }}</slot>
	</button>
</template>

<!-- USAGE - We may add additional props in the future 
	
	<PrimaryButton>Click Me</PrimaryButton>
	<PrimaryButton title="Save" />
-->

