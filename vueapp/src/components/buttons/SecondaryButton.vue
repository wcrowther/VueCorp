<script setup>

	const props = defineProps(
	{
		title: String
	})

</script>

<template>
    <button class="btn-secondary">
		<slot>{{ props.title }}</slot>
	</button>
</template>

<!-- USAGE - We may add additional props in the future 
	
	<SecondaryButton>Click Me</SecondaryButton>
	<SecondaryButton title="Save" />
-->

