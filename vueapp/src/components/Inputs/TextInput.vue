<script setup>

    const props = defineProps (
    {
        labelName:  { type: String, required: true }, 
        ruleName:   { type: String },  
        v$:         { type: Object }
    })

    const modelValue = defineModel()
    const rule  = computed(() => 
    {   
        let rulename = props.ruleName ? props.ruleName : props.labelName.replace(' ','') 
        // console.log('rulename: ' + rulename)

        return rulename
    })

    // ---------------------------------------------------------------------------------------------
    // OriginalValue Does not work as text fields are re-rendered so show as changed 
    // after first refresh. Would need to put in place logic to re-render the component.
    // :key on the top level of the component? Does not seem to work.
    // ---------------------------------------------------------------------------------------------
    // const originalValue = modelValue.value
    // const hasChanged = computed(() => originalValue !== modelValue.value)
    // ---------------------------------------------------------------------------------------------
</script>

<template>
    <div class="mb-3">
        <div class="pb-1 flex justify-between items-baseline">
            <span class="text-color-dark-blue font-bold whitespace-nowrap text-sm"
                :for="props.labelName">
                {{props.labelName}}
            </span>
            <template v-if="v$">
                <span class="italic font-bold text-right text-xs text-color-red" 
                    v-for="error in v$[rule].$errors" :key="error.$uid">
                    {{ error.$message }}
                </span>
            </template>
        </div>
        <div class="flex justify-center items-center relative">
            <input class="w-full" type="text" :id="props.labelName" :name="props.labelName"
                v-model="modelValue" v-bind="$attrs" spellcheck="false" />
        </div>
    </div>
</template>

<!-- 
EXAMPLES:
    <TextInput labelName="Account Name" v-model="account.AccountName" :v$></TextInput>
    <TextInput labelName="Main Email" ruleName="AccountEmail" v-model="account.AccountEmail" :v$></TextInput>

    <span class="inline-block h-2 w-2 text-xs rounded-full" title="Value has been changed" 
    :class="{ 'bg-color-light-blue': hasChanged }">&nbsp;</span>  

---------------------------------------------------------------------
'defineModel' replaces the code below and the defineProps modelValue
----------------------------------------------------------------------
    (in props)    modelValue: { type: String },
    const emits = defineEmits(['update:modelValue'])
    const value = computed(
    {
        get()       { return props.modelValue },
        set(value)  { emits('update:modelValue', value)  }
    })
------------------------------------------------------------------ 
-->

