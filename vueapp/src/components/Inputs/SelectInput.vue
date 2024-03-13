<script setup>

    const props = defineProps (
    {
        // defaultText: { type: String, default: '--- Select ---' }, 
        optionsList: { type: Object, required: true }, 
        labelName:   { type: String, required: true }, 
        ruleName:    { type: String }, 
        v$:          { type: Object, required: true }
    })

    const modelValue = defineModel()
    const rule  = computed(() => props.ruleName ? props.ruleName : props.labelName.replace(' ','') )

</script>

<template>
    <div class="mb-3">
        <div class="pb-1 flex justify-between items-baseline">
            <span class="text-color-dark-blue font-bold whitespace-nowrap text-sm">{{props.labelName}}</span>
            <span v-for="error in v$[rule].$errors" :key="error.$uid"
                class="italic font-bold text-right text-xs text-color-red">
                {{ error.$message }}
            </span>
        </div>
        <select class="w-full p-2.5" name="states" id="states" v-model="modelValue">
            <option value="">----</option>
            <option v-for="(value,key) in optionsList" :key="key" :value="key">{{ value }}</option>
        </select>
    </div>
</template>



<!-- EXAMPLES:
    
    <SelectInput labelName="State / Province" ruleName="StateProvince" v-model="account.StateProvince" 
        :optionsList="usStatesList" :v$ />


-->
