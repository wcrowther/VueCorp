
<script setup>

	const min = 1
	const max = 3
	const modelValue = defineModel (
	{
		type: Number,
		validator(value) {  return value >= min && value <= max }
	})

	const setInfoLevel  = (num) => 
	{
		let val = modelValue.value + num

		if(val < min)
			val = max
		else if(val > max)
			val = min

		modelValue.value = val
	}
	
	const infoLevelText = computed(() =>
	{
		switch (modelValue.value)
		{
			case 1: return "?"
			case 2: return "Info"
			case 3: return "Help"
			default: 2
		}
	})

</script>

<template>
	
	<div v-if="(modelValue > 0 && modelValue < 4)" 
		class="badge-button cursor-pointer text-white bg-color-primary hover:bg-orange"
		:class="{'bg-orange hover:opacity-70': modelValue === 3}"
		@click="setInfoLevel(1)"  @click.right.prevent="setInfoLevel(-1)" 
		title="Change Help detail level.">
		{{infoLevelText}}
	</div>  

</template>





<!-- USAGE

	const appStore      = useAppStore()
	const { infoLevel } = storeToRefs(appStore)

	<InfoButton v-model="infoLevel"></InfoButton>

	<p v-if="infoLevel > 1">
		Lorem ipsum, dolor sit amet consectetur adipisicing elit.
	</p>

	<p class="mt-5" v-if="infoLevel > 2">
		VERBOSE STUFF - Lorem ipsum, dolor sit amet consectetur...
	</p>

-->

