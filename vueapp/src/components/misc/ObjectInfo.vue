<script setup>

	const props = defineProps(
	{
		object: { type: SearchForAccount }
	});

	onMounted(() => 
	{
		console.log('ObjectInfo prop.object: ', props.object instanceof SearchForAccount )
	})

</script>

<template>
	<div class="flex justify-start items-center gap-2 pt-5">

		<slot /> : <div v-html="JSON.stringify(props.object)"></div>
	</div>
</template>