<script setup>

    const iAuditable = defineModel('IAuditable',{
        type: Object,
        required: true,
        validator: (value) => 
        {
            const requiredFields = 
            ["DateCreated", "DateModified", "CreatorName","ModifierName"];

            for (const prop of requiredFields) {
                if (!Object.hasOwn(value, prop)) {
                    console.log(`Error: CreatorBox does not implement: ${prop}`);
                }
            }
            return true;        
        }
    })

</script>

<template>

    <div class="-m-5 mb-5 p-3 flex flex-wrap gap-2 justify-between
        text-slate-400 whitespace-nowrap text-xs italic overflow-hidden">
        <span :title="`Modified: ${dateTimeFormat(iAuditable.DateModified)} By: ${iAuditable.ModifierName}`">
            Modified: {{dateFormat(iAuditable.DateModified)}} 
        </span>
        <span :title="`Created: ${dateTimeFormat(iAuditable.DateCreated)} By: ${iAuditable.CreatorName}`">
            Created: {{dateFormat(iAuditable.DateCreated)}}
        </span> 
    </div>

</template>


<!-- 
USE:  Wrap around creator data to give consistent visual impact.
EXAMPLE: 
    <CreatorBox v-if="!isAddingAccount" :IAuditable="account" />
-->


