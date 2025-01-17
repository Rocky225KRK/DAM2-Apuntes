package org.rockyrk.examenuf1;

import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.databinding.DataBindingUtil;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.rockyrk.examenuf1.adapter.CategoryAdapter;
import org.rockyrk.examenuf1.adapter.ProductAdapter;
import org.rockyrk.examenuf1.databinding.ActivityMainBinding;
import org.rockyrk.examenuf1.model.Category;
import org.rockyrk.examenuf1.model.CategoryEntry;
import org.rockyrk.examenuf1.model.Product;
import org.rockyrk.examenuf1.viewmodel.ViewModel;

public class MainActivity extends AppCompatActivity implements CategoryAdapter.CategoryAdapterListener {
    private ActivityMainBinding binding;
    private ViewModel viewModel;
    private CategoryAdapter categoryAdapter;
    private ProductAdapter productAdapter;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding= DataBindingUtil.setContentView(this,R.layout.activity_main);

        viewModel=new ViewModelProvider(this).get(ViewModel.class);

        binding.setViewmodel(viewModel);
        binding.setLifecycleOwner(this);

        viewModel.getAllCategories().observe(this,categories -> {
            categoryAdapter=new CategoryAdapter(categories,this,this);
            binding.rcyCategories.setAdapter(categoryAdapter);
        });

        binding.rcyCategories.setHasFixedSize(true);
        binding.rcyCategories.setLayoutManager(new LinearLayoutManager(this, RecyclerView.HORIZONTAL,false));

        viewModel.getCategory().observe(this,categoryEntry -> {
            productAdapter =new ProductAdapter(categoryEntry.getProducts(),this);
            binding.rcyProducts.setAdapter(productAdapter);
        });

        binding.rcyProducts.setHasFixedSize(true);
        binding.rcyProducts.setLayoutManager(new LinearLayoutManager(this,RecyclerView.VERTICAL,false));
    }

    @Override
    public void onCategorySelected(Category category) {
        viewModel.downloadData(category.getId());
    }
}