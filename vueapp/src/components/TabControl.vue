<script setup>

    import { ref } from 'vue'

    const props = defineProps({
        id: { type: String, default: 'TabControl' },
		tabList: { type: Array, default: () => ['One', 'Two', 'Three'] }
	})

    const activeTab = ref(props.tabList[0])
    const isActive	= (tab) => tab === activeTab.value

</script>

<template>

    <div :id="props.id" class="h-full">

        <!-- Tabs -->
        <div class="flex gap-2 justify-start h-8 z-20 pl-5 border-b-2 border-slate-300">

            <div v-for="(tab,idx) in props.tabList" :key="idx"
                class="px-3 pt-1 rounded-t-md border-2 bg-slate-300 border-slate-300 border-b-0 
                    font-bold select-none relative bottom-[-2px]"
                :class="{ 'bg-white': isActive(tab) }" @click="activeTab = tab">
                <span>{{ tab }}</span>
            </div>

        </div>

        <!-- Content -->
        <div class="z-10 h-full min-h-60 p-5 opacity-100 pb-3 bg-white 
            border-2 border-slate-300 border-t-0 overflow-y-auto scrollbar-thin">

           <slot></slot>
           <template v-for="(tab,idx) in props.tabList" :key="idx">
               <slot v-if="activeTab == tab" :name="tab"></slot>
           </template>

        </div>

    </div>

</template>

<!-- USAGE:

    <TabControl class="mb-10" :tabList="['First', 'Second', 'Third']" >

        <div class="text-center p-3 border">Default slot</div>

        <template #First>       
            <div class="p-5">
                <div class="font-bold mb-3">First Content</div>
            </div>
        </template>

        <template #Second>       
            <div class="p-5">
                <div class="font-bold mb-3">Second Content</div>
            </div>
        </template>

        <template #Third>       
            <div class="p-5">
                <div class="font-bold text-red mb-3">Important</div>
            </div>
        </template>

    </TabControl>
-->