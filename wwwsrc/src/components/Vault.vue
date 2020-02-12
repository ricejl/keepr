<template>
  <div class="name">
    <div class="card" style="width: 10rem;">
      <img src="//placehold.it/100x100" class="card-img-top" alt="..." />
      <div class="card-body">
        {{ vaultData.name }}
        <i
          class="far fa-times-circle"
          title="delete"
          @click="deleteVault(vaultData.id)"
        ></i>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "vault",
  mounted() {},
  props: ["vaultData"],
  methods: {
    deleteVault(id) {
      this.$store.dispatch("deleteVault", id);
    }
  }
};
</script>

<style></style>
