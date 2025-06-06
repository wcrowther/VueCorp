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
        <div class="flex justify-start gap-px w-fit mb-5 rounded-full overflow-hidden">
        
            <template v-for="(tab,idx) in props.tabList" :key="idx">
                <div :class="['py-2 px-5 text-white font-bold', 
                    isActive(tab) ? 'bg-black' :'bg-gray']" 
                    @click="activeTab = tab">
                    <span>{{ tab }}</span>
                </div>
            </template>

        </div>

        <!-- Content -->
        <div class="z-10 h-full min-h-60 opacity-100 pb-3 bg-white 
             border-t-0 overflow-y-auto scrollbar-thin">

           <slot></slot>
           <template v-for="(tab,idx) in props.tabList" :key="idx">
               <slot v-if="activeTab == tab" :name="tab"></slot>
           </template>

        </div>

    </div>

</template>

<style lang="postcss" scoped>


</style> 

<!-- USAGE:

    <WizardControl class="mb-10" :tabList="['First', 'Second', 'Third']" >

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

    </WizardControl>
-->