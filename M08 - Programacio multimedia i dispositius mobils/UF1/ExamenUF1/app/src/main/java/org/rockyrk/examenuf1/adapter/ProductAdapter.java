package org.rockyrk.examenuf1.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import org.rockyrk.examenuf1.R;
import org.rockyrk.examenuf1.model.Product;

import java.util.List;

public class ProductAdapter extends RecyclerView.Adapter<ProductAdapter.ViewHolder>{
    private List<Product> products;
    private Context c;

    public ProductAdapter(List<Product> products, Context c) {
        this.products = products;
        this.c = c;
    }

    @NonNull
    @Override
    public ProductAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view= LayoutInflater.from(parent.getContext()).inflate(R.layout.product_card,parent,false);
        return new ProductAdapter.ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ProductAdapter.ViewHolder holder, int position) {
        Product current= products.get(position);
        holder.txvName.setText(current.getName());
        holder.txvPrice.setText(current.getPrice()+"€/u");
        holder.txvStock.setText("Stock: "+current.getStock());
        holder.edtQty.setText(current.getQtySelected()+"");
        holder.edtQty.setEnabled(false);
        disableButtons(holder,current);

        holder.btnMes.setOnClickListener(view -> {
            int num=Integer.parseInt(""+holder.edtQty.getText());
            num++;
            holder.edtQty.setText(""+num);
            products.get(position).setQtySelected(num);
            disableButtons(holder,current);
        });

        holder.btnMenys.setOnClickListener(view -> {
            int num=Integer.parseInt(""+holder.edtQty.getText());
            num--;
            holder.edtQty.setText(""+num);
            products.get(position).setQtySelected(num);
            disableButtons(holder,current);
        });
    }

    @Override
    public int getItemCount() {
        return products.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView txvName,txvPrice,txvStock;
        Button btnMes,btnMenys;
        EditText edtQty;

        public ViewHolder(@NonNull View row) {
            super(row);
            txvName=row.findViewById(R.id.txvName);
            txvPrice=row.findViewById(R.id.txvPrice);
            txvStock=row.findViewById(R.id.txvStock);
            btnMes=row.findViewById(R.id.btnMes);
            btnMenys=row.findViewById(R.id.btnMenys);
            edtQty=row.findViewById(R.id.edtQty);
        }
    }

    public void disableButtons(ProductAdapter.ViewHolder holder,Product current){
        int num=Integer.parseInt(""+holder.edtQty.getText());

        if(current.getStock()<=0){
            holder.btnMenys.setEnabled(false);
            holder.btnMes.setEnabled(false);
        }
        holder.btnMenys.setEnabled(num != 0);
        holder.btnMes.setEnabled(num<current.getStock());
    }
}
