<script setup>

    const props = defineProps (
    {
        labelName:  { type: String, required: true }
    })

    const modelValue = defineModel()

</script>

<template>
    <div class="flex">
        <input name="{{props.labelName}}" type="checkbox" v-model="modelValue">
        <span class="ml-2 text-color-dark-blue font-bold whitespace-nowrap text-xs">
            {{props.labelName}}
        </span>
    </div>
</template>

<!--
Examples: 
    <CheckboxInput labelName="Is Active" v-model="account.IsActive" />
-->
