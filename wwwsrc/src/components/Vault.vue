<template>
  <div class="vault-component">
    <div class="card" style="width: 10rem;">
      <router-link :to="{ name: 'vault', params: { vauldId: vaultData.id } }">
        <img
          src="https://sfbeerweek.org/upload/e3fd652ba506415d/menageriesmall2.jpg"
          class="card-img-top"
          alt="vault-image"
        />
      </router-link>
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
  name: "vault-component",
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
