<script setup>

    const props = defineProps (
    {
        IAuditable:  
        { 
            type: Object, 
            required: true,
            validator(value){
                var required = ["DateCreated", "DateModified", "CreatorId", "ModifierId"]
                if(!required.every(prop => Object.hasOwn(value, prop))) 
                    console.warn('CreatorBox: IAuditable object must implement all required fields')
                return true
            }
        } 
    })

    const { DateCreated, DateModified, CreatorId, ModifierId } = props.IAuditable;

</script>

<template>

    <div class="-m-5 mb-5 p-3 flex flex-wrap gap-2 justify-between
        text-slate-400 whitespace-nowrap text-xs italic overflow-hidden">
        <span :title="`Modified: ${dateTimeFormat(DateModified)}  by Will Crowther ${CreatorId}`">
            Modified: {{dateFormat(DateModified)}} 
        </span>
        <span :title="`Created: ${dateTimeFormat(DateCreated)} by Will Crowther ${ModifierId}`">
            Created: {{dateFormat(DateCreated)}}
        </span>
    </div>

</template>


<!-- 
USE:  Wrap around creator data to give consistent visual impact.
EXAMPLE: 
    <CreatorBox v-if="!isAddingAccount" :IAuditable="account" />
-->


