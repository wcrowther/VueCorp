// vite.config.mjs
import { fileURLToPath, URL } from "node:url";
import { defineConfig } from "file:///C:/Git/VueCorp/vueapp/node_modules/vite/dist/node/index.js";
import mkcert from "file:///C:/Git/VueCorp/vueapp/node_modules/vite-plugin-mkcert/dist/mkcert.mjs";
import vue from "file:///C:/Git/VueCorp/vueapp/node_modules/@vitejs/plugin-vue/dist/index.mjs";
import VueRouter from "file:///C:/Git/VueCorp/vueapp/node_modules/unplugin-vue-router/dist/vite.mjs";
import AutoImport from "file:///C:/Git/VueCorp/vueapp/node_modules/unplugin-auto-import/dist/vite.js";
import Components from "file:///C:/Git/VueCorp/vueapp/node_modules/unplugin-vue-components/dist/vite.js";
import { VueRouterAutoImports } from "file:///C:/Git/VueCorp/vueapp/node_modules/unplugin-vue-router/dist/index.mjs";
var __vite_injected_original_import_meta_url = "file:///C:/Git/VueCorp/vueapp/vite.config.mjs";
var vite_config_default = defineConfig({
  plugins: [
    AutoImport({
      dts: true,
      vueTemplate: true,
      dirs: ["./src/helpers", "./src/models", "./src/stores"],
      imports: [
        "vue",
        VueRouterAutoImports,
        {
          "@vueuse/core": [
            "useClipboard",
            "useDebounceFn",
            "useLocalStorage",
            "useWindowSize",
            ["useDraggable", "Draggable"]
          ],
          "pinia": [
            "storeToRefs",
            "defineStore"
          ],
          "@vuelidate/core": [
            "useVuelidate"
          ]
        }
      ],
      eslintrc: {
        enabled: true
      }
    }),
    VueRouter({
      dts: true
    }),
    vue(),
    mkcert(),
    Components({
      dirs: ["./src/components", "./src/layouts"],
      dts: true
    })
  ],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", __vite_injected_original_import_meta_url))
    }
  },
  server: {
    proxy: {
      "^/weatherforecast": {
        target: "https://localhost:7199/",
        secure: false
      }
    },
    port: 7200
  }
});
export {
  vite_config_default as default
};
//# sourceMappingURL=data:application/json;base64,ewogICJ2ZXJzaW9uIjogMywKICAic291cmNlcyI6IFsidml0ZS5jb25maWcubWpzIl0sCiAgInNvdXJjZXNDb250ZW50IjogWyJjb25zdCBfX3ZpdGVfaW5qZWN0ZWRfb3JpZ2luYWxfZGlybmFtZSA9IFwiQzpcXFxcR2l0XFxcXFZ1ZUNvcnBcXFxcdnVlYXBwXCI7Y29uc3QgX192aXRlX2luamVjdGVkX29yaWdpbmFsX2ZpbGVuYW1lID0gXCJDOlxcXFxHaXRcXFxcVnVlQ29ycFxcXFx2dWVhcHBcXFxcdml0ZS5jb25maWcubWpzXCI7Y29uc3QgX192aXRlX2luamVjdGVkX29yaWdpbmFsX2ltcG9ydF9tZXRhX3VybCA9IFwiZmlsZTovLy9DOi9HaXQvVnVlQ29ycC92dWVhcHAvdml0ZS5jb25maWcubWpzXCI7XHJcbmltcG9ydCB7IGZpbGVVUkxUb1BhdGgsIFVSTCB9ICAgZnJvbSAnbm9kZTp1cmwnXHJcbmltcG9ydCB7IGRlZmluZUNvbmZpZyB9ICAgICAgICAgZnJvbSAndml0ZSdcclxuaW1wb3J0IG1rY2VydCAgICAgICAgICAgICAgICAgICBmcm9tICd2aXRlLXBsdWdpbi1ta2NlcnQnXHJcbmltcG9ydCB2dWUgICAgICAgICAgICAgICAgICAgICAgZnJvbSAnQHZpdGVqcy9wbHVnaW4tdnVlJ1xyXG5pbXBvcnQgVnVlUm91dGVyICAgICAgICAgICAgICAgIGZyb20gJ3VucGx1Z2luLXZ1ZS1yb3V0ZXIvdml0ZSdcclxuaW1wb3J0IEF1dG9JbXBvcnQgICAgICAgICAgICAgICBmcm9tICd1bnBsdWdpbi1hdXRvLWltcG9ydC92aXRlJ1xyXG5pbXBvcnQgQ29tcG9uZW50cyAgICAgICAgICAgICAgIGZyb20gJ3VucGx1Z2luLXZ1ZS1jb21wb25lbnRzL3ZpdGUnXHJcbmltcG9ydCB7IFZ1ZVJvdXRlckF1dG9JbXBvcnRzIH0gZnJvbSAndW5wbHVnaW4tdnVlLXJvdXRlcidcclxuXHJcbmV4cG9ydCBkZWZhdWx0IGRlZmluZUNvbmZpZyh7XHJcbiAgICBwbHVnaW5zOiBcclxuICAgIFtcclxuICAgICAgICBBdXRvSW1wb3J0KHtcclxuICAgICAgICAgICAgZHRzOiB0cnVlLFxyXG4gICAgICAgICAgICB2dWVUZW1wbGF0ZTogdHJ1ZSxcclxuICAgICAgICAgICAgZGlyczogWycuL3NyYy9oZWxwZXJzJywgJy4vc3JjL21vZGVscycsICcuL3NyYy9zdG9yZXMnXSxcclxuICAgICAgICAgICAgaW1wb3J0czogW1xyXG4gICAgICAgICAgICAgICAgJ3Z1ZScsXHJcbiAgICAgICAgICAgICAgICBWdWVSb3V0ZXJBdXRvSW1wb3J0cyxcclxuICAgICAgICAgICAgICAgIHsgXHJcbiAgICAgICAgICAgICAgICAgICAgJ0B2dWV1c2UvY29yZSc6IFxyXG4gICAgICAgICAgICAgICAgICAgIFtcclxuICAgICAgICAgICAgICAgICAgICAgICAgJ3VzZUNsaXBib2FyZCcsXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICd1c2VEZWJvdW5jZUZuJyxcclxuICAgICAgICAgICAgICAgICAgICAgICAgJ3VzZUxvY2FsU3RvcmFnZScsXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICd1c2VXaW5kb3dTaXplJyxcclxuICAgICAgICAgICAgICAgICAgICAgICAgWyd1c2VEcmFnZ2FibGUnICwgJ0RyYWdnYWJsZSddXHJcbiAgICAgICAgICAgICAgICAgICAgXSxcclxuICAgICAgICAgICAgICAgICAgICAncGluaWEnOiBcclxuICAgICAgICAgICAgICAgICAgICBbXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICdzdG9yZVRvUmVmcycsXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICdkZWZpbmVTdG9yZSdcclxuICAgICAgICAgICAgICAgICAgICBdLFxyXG4gICAgICAgICAgICAgICAgICAgICdAdnVlbGlkYXRlL2NvcmUnOiBcclxuICAgICAgICAgICAgICAgICAgICBbXHJcbiAgICAgICAgICAgICAgICAgICAgICAgICd1c2VWdWVsaWRhdGUnXHJcbiAgICAgICAgICAgICAgICAgICAgXVxyXG4gICAgICAgICAgICAgICAgfVx0XHJcbiAgICAgICAgICAgIF0sXHRcclxuICAgICAgICAgICAgZXNsaW50cmM6IHtcclxuICAgICAgICAgICAgICAgIGVuYWJsZWQ6IHRydWVcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH0pLFxyXG4gICAgICAgIFZ1ZVJvdXRlcih7XHJcbiAgICAgICAgICAgIGR0czogdHJ1ZVxyXG4gICAgICAgIH0pLCAgICAgICAgXHJcbiAgICAgICAgdnVlKCksXHJcbiAgICAgICAgbWtjZXJ0KCksXHJcbiAgICAgICAgQ29tcG9uZW50cyh7XHJcbiAgICAgICAgICAgIGRpcnM6IFsnLi9zcmMvY29tcG9uZW50cycsICcuL3NyYy9sYXlvdXRzJ10sXHJcbiAgICAgICAgICAgIGR0czogdHJ1ZVxyXG4gICAgICAgIH0pXHJcbiAgICBdLFxyXG4gICAgcmVzb2x2ZToge1xyXG4gICAgICAgIGFsaWFzOiB7XHJcbiAgICAgICAgICAgICdAJzogZmlsZVVSTFRvUGF0aChuZXcgVVJMKCcuL3NyYycsIGltcG9ydC5tZXRhLnVybCkpXHJcbiAgICAgICAgfVxyXG4gICAgfSxcclxuICAgIHNlcnZlcjoge1xyXG4gICAgICAgIHByb3h5OiB7XHJcbiAgICAgICAgICAgICdeL3dlYXRoZXJmb3JlY2FzdCc6IHtcclxuICAgICAgICAgICAgICAgIHRhcmdldDogJ2h0dHBzOi8vbG9jYWxob3N0OjcxOTkvJywgXHJcbiAgICAgICAgICAgICAgICBzZWN1cmU6IGZhbHNlXHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9LFxyXG4gICAgICAgIHBvcnQ6IDcyMDBcclxuICAgIH1cclxufSlcclxuIl0sCiAgIm1hcHBpbmdzIjogIjtBQUNBLFNBQVMsZUFBZSxXQUFhO0FBQ3JDLFNBQVMsb0JBQTRCO0FBQ3JDLE9BQU8sWUFBOEI7QUFDckMsT0FBTyxTQUE4QjtBQUNyQyxPQUFPLGVBQThCO0FBQ3JDLE9BQU8sZ0JBQThCO0FBQ3JDLE9BQU8sZ0JBQThCO0FBQ3JDLFNBQVMsNEJBQTRCO0FBUnFILElBQU0sMkNBQTJDO0FBVTNNLElBQU8sc0JBQVEsYUFBYTtBQUFBLEVBQ3hCLFNBQ0E7QUFBQSxJQUNJLFdBQVc7QUFBQSxNQUNQLEtBQUs7QUFBQSxNQUNMLGFBQWE7QUFBQSxNQUNiLE1BQU0sQ0FBQyxpQkFBaUIsZ0JBQWdCLGNBQWM7QUFBQSxNQUN0RCxTQUFTO0FBQUEsUUFDTDtBQUFBLFFBQ0E7QUFBQSxRQUNBO0FBQUEsVUFDSSxnQkFDQTtBQUFBLFlBQ0k7QUFBQSxZQUNBO0FBQUEsWUFDQTtBQUFBLFlBQ0E7QUFBQSxZQUNBLENBQUMsZ0JBQWlCLFdBQVc7QUFBQSxVQUNqQztBQUFBLFVBQ0EsU0FDQTtBQUFBLFlBQ0k7QUFBQSxZQUNBO0FBQUEsVUFDSjtBQUFBLFVBQ0EsbUJBQ0E7QUFBQSxZQUNJO0FBQUEsVUFDSjtBQUFBLFFBQ0o7QUFBQSxNQUNKO0FBQUEsTUFDQSxVQUFVO0FBQUEsUUFDTixTQUFTO0FBQUEsTUFDYjtBQUFBLElBQ0osQ0FBQztBQUFBLElBQ0QsVUFBVTtBQUFBLE1BQ04sS0FBSztBQUFBLElBQ1QsQ0FBQztBQUFBLElBQ0QsSUFBSTtBQUFBLElBQ0osT0FBTztBQUFBLElBQ1AsV0FBVztBQUFBLE1BQ1AsTUFBTSxDQUFDLG9CQUFvQixlQUFlO0FBQUEsTUFDMUMsS0FBSztBQUFBLElBQ1QsQ0FBQztBQUFBLEVBQ0w7QUFBQSxFQUNBLFNBQVM7QUFBQSxJQUNMLE9BQU87QUFBQSxNQUNILEtBQUssY0FBYyxJQUFJLElBQUksU0FBUyx3Q0FBZSxDQUFDO0FBQUEsSUFDeEQ7QUFBQSxFQUNKO0FBQUEsRUFDQSxRQUFRO0FBQUEsSUFDSixPQUFPO0FBQUEsTUFDSCxxQkFBcUI7QUFBQSxRQUNqQixRQUFRO0FBQUEsUUFDUixRQUFRO0FBQUEsTUFDWjtBQUFBLElBQ0o7QUFBQSxJQUNBLE1BQU07QUFBQSxFQUNWO0FBQ0osQ0FBQzsiLAogICJuYW1lcyI6IFtdCn0K
