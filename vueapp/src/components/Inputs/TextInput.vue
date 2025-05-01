<script setup>

    const props = defineProps (
    {
        labelName:  { type: String, required: true }, 
        ruleName:   { type: String }, 
        spellCheck: { type: Boolean },
        v$:         { type: Object }
    })

    const modelValue = defineModel()
    const rule  = computed(() => props.ruleName ? props.ruleName : props.labelName.replace(' ',''))

</script>

<template>
    <div class="mb-3">
        <div class="pb-1 flex justify-between items-baseline">
            <span class="text-color-dark-blue font-bold whitespace-nowrap text-xs"
                :for="props.labelName">
                {{props.labelName}}
            </span>
            <template v-if="v$ && v$[rule] && v$[rule].$errors">
                <span class="italic font-bold text-right text-xs text-color-red" 
                    v-for="error in v$[rule].$errors" :key="error.$uid">
                    {{ error.$message }}
                </span>
            </template>
        </div>
        <div class="flex justify-center items-center relative">
            <input class="w-full text-sm" type="text" :id="props.labelName" :name="props.labelName"
                v-model="modelValue" v-bind="$attrs" :spellcheck="props.spellCheck" />
        </div>
    </div>
</template>

<!-- 
EXAMPLES:
    <TextInput labelName="Account Name" v-model="account.AccountName" :v$></TextInput>
    <TextInput labelName="Main Email" ruleName="AccountEmail" v-model="account.AccountEmail" :v$></TextInput>

    <span class="inline-block h-2 w-2 text-xs rounded-full" title="Value has been changed" 
    :class="{ 'bg-color-light-blue': hasChanged }">&nbsp;</span>  

    -------------------------------------------------------------------------------------------
    'defineModel' replaced the code below from older vue version and the defineProps modelValue
    -------------------------------------------------------------------------------------------
    (in props)    modelValue: { type: String },
    const emits = defineEmits(['update:modelValue'])
    const value = computed(
    {
        get()       { return props.modelValue },
        set(value)  { emits('update:modelValue', value)  }
    })
    ------------------------------------------------------------------------------------------- 
-->

