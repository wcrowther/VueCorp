<script setup>

    import { useDraggable }                 from '@vueuse/core'

    const pager = computed(() => props.pager); 

    const props = defineProps({
        pager: { type: Pager, required: true },
        show:  { type: Boolean, default: false }
    })

    const el = ref(null)

    // `style` will be a helper computed for `left: ?px; top: ?px;`
    const { style } = useDraggable(el, 
    {
        initialValue: { x: 400, y: 30 },
    })
</script>

<template>
    <Teleport v-if="show" to="body">    
        <div id="pagerDebugger" ref="el" :style="style" 
            class="absolute top-14 right-0 z-[1000] w-[200px] pb-3 mb-1 drop-shadow-2xl 
                text-sm/loose leading-[25px] bg-white border"> 

            <div class="p-2 bg-color-blue text-white font-bold ">Pager Debugger</div>

            <div class="px-2 bg-[#ddd]">CurrentRecord:   {{ pager.CurrentRecord }}</div>
            <div class="px-2 bg-[#ddd]">GroupSize:       {{ pager.GroupSize }}</div>
            <div class="px-2 bg-[#ddd]">PageSize:        {{ pager.PageSize }}</div>
            <div class="px-2 bg-[#ddd]">TotalCount:      {{ pager.TotalCount }}</div>
            <div class="px-2 bg-[#ddd]">Search.Filter:   {{ pager.Search.Filter }}</div>
            <div class="px-2 bg-[#ddd]">Search.Sort:     {{ pager.Search.Sort }}</div>
            <div class="px-2 bg-[#ddd]">Search.SortDesc: {{ pager.Search.SortDesc }}</div>
        
            <div class="px-2">currentFirst:      {{ pager.currentFirst() }}</div>
            <div class="px-2">previous:          {{ pager.previous() }}</div>
            <div class="px-2">next:              {{ pager.next() }}</div>
            <div class="px-2">offset:            {{ pager.offset() }}</div>
            <div class="px-2">hasRecords:        {{ pager.hasRecords() }}</div>
        
            <div class="px-2 bg-[#ddd] mb-1">currentPage: {{ pager.currentPage() }}</div>
            <div class="px-2">firstPage:         {{ pager.firstPage() }}</div>
            <div class="px-2">lastPage:          {{ pager.lastPage() }}</div>
            <div class="px-2">previousPage:      {{ pager.previousPage() }}</div>
            <div class="px-2">nextPage:          {{ pager.nextPage() }}</div>
            <div class="px-2">hasMultiplePages:  {{ pager.hasMultiplePages() }}</div>
            
            <div class="px-2 bg-[#ddd] mb-1">currentGroup: {{ pager.currentGroup() }}</div>
            <div class="px-2">firstGroup:        {{ pager.firstGroup() }}</div>
            <div class="px-2">lastGroup:         {{ pager.lastGroup() }}</div>
            <div class="px-2">previousGroup:     {{ pager.previousGroup() }}</div>
            <div class="px-2">nextGroup:         {{ pager.nextGroup() }}</div>
            <div class="px-2">hasPreviousGroup:  {{ pager.hasPreviousGroup() }}</div>
            <div class="px-2">hasNextGroup:      {{ pager.hasNextGroup() }}</div>
        </div>
    </Teleport>    
</template>

<style lang="postcss"  scoped></style>


    

