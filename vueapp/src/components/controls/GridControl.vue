<script setup>

    const width 	= ref(15) 
    const height 	= ref(10) 
	
    defineOptions({ inheritAttrs: false })

    const rows = computed(() => Array.from({ length: height.value }))
    const cols = computed(() => Array.from({ length: width.value }))

</script>

<template>
	<div>Rows: {{ rows.length }}</div>
	<div>Cols: {{ cols.length }}</div>

	<div class="w-fit mx-auto" v-bind='$attrs' :style="{ display: 'grid', gap: '4px', 
		gridTemplateRows: `repeat(${width}, 1fr)`, gridTemplateColumns: `repeat(${height}, 1fr)`}">

		<template v-for="(row, rowIndex) in rows" :key="rowIndex">

			<template v-for="(col, colIndex) in cols" :key="`${rowIndex}-${colIndex}`">
				<div class="size-7 bg-white border border-blue aspect-square flex justify-center items-center" 
					:style="{ gridRow: rowIndex + 1, gridColumn: colIndex + 1 }" 
					title="Row: {{ rowIndex }}, Col: {{ colIndex }}">

				</div>
			</template>

		</template>

	</div>

</template>
