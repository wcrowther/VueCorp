<script setup>

	// You can add a :class="[showWords ? 'ml-20' : 'mr-20']" to the component invocation to override the margins

	defineOptions({ inheritAttrs: false })

	const props = defineProps(
	{
		title: 				String,
		buttonName: 		String,
		buttonColor:		String,
		falseText:        	{ type: String, default: 'Off'},
		trueText:         	{ type: String, default: 'On'}
	})

    const modelValue = defineModel()
	
</script>

<template>

	<div class="flex items-center relative rounded-full h-8 border font-normal w-fit
		p-1 border-warm-600 bg-white select-none" 
		@click="modelValue = !modelValue" :title="title">

		<span class="flex absolute top-0 py-1 z-10 left-[9px]">{{ props.falseText }}</span>
		<span class="flex absolute top-0 py-1 z-10 right-3">{{ props.trueText }}</span>
		<div class="relative z-20 inline-block rounded-full px-3 py-0 h-6 text-center align-middle tracking-wide
			transition-all duration-200" :class="[modelValue ? 'mr-8' : 'ml-8', $attrs.class]">
			<span class="text-sm hidden md:inline">{{ props.buttonName }}</span>
			<span class="inline md:hidden px-1">&nbsp;</span>
		</div> 
		
	</div>
  
</template>
  

<!-- Examples (Boolean button)
	
	const showWords = ref(false)

	<SwitchButton class="bg-color-orange text-white" buttonName="PinPopout" v-model="showWords" />

    <div class="mt-7 flex flex-wrap gap-5 mb-3">
        <SwitchButton class="bg-color-mid-blue text-white transition-colors" buttonName="Active"  
            :class="{'!bg-color-dark-blue' : account.IsActive}" v-model="account.IsActive" />
    </div> 
-->
  
  
  
  
  
  