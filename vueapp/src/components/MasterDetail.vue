<script setup>

	import { computed }			from 'vue'
	import { useBreakpoints } 	from '@vueuse/core' 
	import tailwindConfig		from '../../tailwind.config.mjs'

	const props = defineProps(
	{
		gridTemplateColumns: 	{ type: String,  required: true },
		fullScreen: 			{ type: Boolean, default: false },   
		enableWideScreen: 		{ type: Boolean, default: true }, 
		wideBreakpoint: 		{ type: String,  default: 'xl' },
		colsVisible:			{ type: Number,  default: 1 },
	})

	// eslint-disable-next-line no-unused-vars
	const detailIndex 	= defineModel('detailIndex', { type: Number , 	required: true})	
	const showDetail 	= defineModel('showDetail',  { type: Boolean, 	required: true })	

	const screens 				= tailwindConfig.theme.screens
	const breakpoints  			= useBreakpoints(screens)
	const greaterThanBreakpoint = breakpoints.greater(props.wideBreakpoint) 
	const isWideScreen  		= computed(() => props.enableWideScreen && greaterThanBreakpoint.value )
	const gridColumns			= computed(() => props.gridTemplateColumns.replaceAll(' ','_').split("_").length - props.colsVisible)
	const getDetailClass		= computed(() => 
	{	
		return props.fullScreen ? 'full-screen' : isWideScreen.value ? 'wide-screen' : 'over-table'
	})

	const closeDetail = ()=> { showDetail.value = false; console.log(`showDetail: ${showDetail.value}`) }

</script>

<template>	

	<div class="relative flex" v-bind="$attrs" id="MasterDetail">

		<!-- Master -->
		<div class="grow relative grid z-5 overflow-auto h-full w-1/2"
			:style="`grid-template-columns: ${gridTemplateColumns}`" id="Master">
            <slot name="master"></slot>
		</div>

		<Teleport defer to="body" :disabled="!fullScreen">  

			<!-- Detail -->
			<div v-show="showDetail || isWideScreen" 
				:class="getDetailClass" id="Detail"
				:style="{ 'grid-template-columns': isWideScreen && !fullScreen ? '' : gridTemplateColumns  }">

				<div v-if="fullScreen || !isWideScreen "
					@click="closeDetail" class="close-icon">x</div>
				
				<div class="h-full w-full" 
					:style="{'grid-column': isWideScreen && !fullScreen ? '': `${props.colsVisible + 1} / span ${gridColumns}`}">
					<slot name="detail" :isWideScreen="isWideScreen"></slot>
				</div>
			</div>
		</Teleport>

	</div>
</template>



<style scoped>

	.over-table  { @apply absolute left-0 right-0 top-0 bottom-0 z-10 h-full 
		grid pointer-events-none col-start-2 col-span-4 }

	.wide-screen { @apply relative flex justify-stretch items-stretch w-1/2 h-full}

	.full-screen { @apply absolute left-0 right-0 top-0 bottom-0 z-10 h-full 
		bg-white pointer-events-none }

	.close-icon  { @apply absolute top-2 right-2 rounded-full h-6 w-6 z-[100] 
		bg-white font-bold text-xl leading-[18px] text-center align-middle
		text-slate hover:bg-slate-200 hover:text-black pointer-events-auto }

</style>


<!--  STUFF:

`'${colsVisible} / span ${gridColumns}'`	

<div v-if="showDetailId != 0" 
	class="z-[150] absolute bottom-3 right-3">
	teleportTo: {{ teleportTo }} | showDetailId (in component): {{ showDetailId }}
</div>


:style="{'grid-column-start': isWideScreen ? '': '2',
'grid-column' 		: isWideScreen ? '': 'span 4'}"> 

:style="{'grid-column': isWideScreen ? '': '1 / span 2'"> 

:class="{'col-start-2 col-span-4' : !isWideScreen }"> 


	<div class="flex gap-2 items-center ml-5 mb-3">
		<span class="border border-red rounded-full px-3 py-1" title="enableWideScreen">
			<span class="hidden lg:inline">enableWideScreen:</span> {{ props.enableWideScreen }}
		</span>
		<span class="border border-red rounded-full px-3 py-1" title="fullScreen">
			<span class="hidden lg:inline">fullScreen:</span> {{ props.fullScreen }}
		</span>
		<span class="border border-red rounded-full px-3 py-1" title="isWideScreen">
			<span class="hidden lg:inline">isWideScreen:</span> {{ isWideScreen }}
		</span>
		<span class="border border-red rounded-full px-3 py-1" title="showDetail">
			<span class="hidden lg:inline">showDetail:</span> {{ showDetail }}
		</span>
		<span class="border border-red rounded-full px-3 py-1" title="detailIndex">
			<span class="hidden lg:inline">detailIndex:</span> {{ detailIndex }}
		</span>
	</div>

-->
