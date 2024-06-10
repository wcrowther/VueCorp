<script setup>

    const props = defineProps (
    {
        showDefault:        { type: Boolean, default: true },
        defaultText:        { type: String,  default: '-----' }, 
        defaultDisabled:    { type: Boolean, default: true },
        optionsList:        { type: Object,  required: true }, 
        labelName:          { type: String,  required: true }, 
        ruleName:           { type: String }, 
        v$:                 { type: Object }
    })

    const modelValue = defineModel()
    const rule  = computed(() => props.ruleName ? props.ruleName : props.labelName.replace(' ','') )

</script>

<template>
    <div class="mb-3">
        <div class="pb-1 flex justify-between items-baseline">
            <span class="text-color-dark-blue font-bold whitespace-nowrap text-sm">{{props.labelName}}</span>
            <template v-if="v$">
                <span v-for="error in v$[rule].$errors" :key="error.$uid"
                    class="italic font-bold text-right text-xs text-color-red">
                    {{ error.$message }}
                </span>
            </template> 
        </div>
        <select class="w-full p-2.5" name="states" id="states" v-bind="$attrs" v-model="modelValue">
            <option v-if="showDefault" :disabled="defaultDisabled" value="">{{ defaultText }}</option>
            <option v-for="(value,key) in optionsList" :key="key" :value="key">{{ value }}</option>
        </select>
    </div>
</template>



<!-- EXAMPLES:
    
    <SelectInput labelName="State / Province" ruleName="StateProvince" v-model="account.StateProvince" 
        :optionsList="usStatesList" :v$ />


-->
