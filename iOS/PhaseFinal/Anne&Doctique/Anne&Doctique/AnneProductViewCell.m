//
//  AnneProductViewCell.m
//  Anne&DocTique2
//
//  Created by Kapi on 28/05/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "AnneProductViewCell.h"
#import "AnneProduct.h"

@interface AnneProductViewCell ()
//@property (strong, nonatomic) IBOutlet UILabel *titleLabel;
//@property (strong, nonatomic) IBOutlet UILabel *detailsLabel;

//@property (strong, nonatomic) IBOutlet UIImageView *iconView;
@end


@implementation AnneProductViewCell


- (void)awakeFromNib {
    [super awakeFromNib];
    
    self.backgroundColor = [UIColor whiteColor];
    
    UIView* selectedBGView = [[UIView alloc] initWithFrame:self.bounds];
    selectedBGView.backgroundColor = self.tintColor;
    self.selectedBackgroundView = selectedBGView;
    
    
}

- (void)setProduct:(NSString *)product {
    //if (![product isEqual:_product]) {
        //_product = product;
    self.text.text = product;//.description;
        //self.author.text = _product.author;
        
   // }
}

-(void)configureWithTextAuthor:(NSString*)productAuthor {
        self.author.text = (NSString*) productAuthor;
}
-(void)configureWithTextDescription:(NSString*)productDescription{
    self.text.text = (NSString*) productDescription;
}
-(void)configureWithTextDate:(NSString*)productDate{
    self.date.text = (NSString *) productDate;
}
 
 -(void) setDeserveCount:(int) count {
     //[youDeservedIt setTitle:[NSString stringWithFormat:@"you deserved(%d)", count] forState:UIControlStateNormal];
 }
 
 -(void) setLifeSucksCount:(int) count {
 //[yourLifeSucks setTitle:[NSString stringWithFormat:@"your life sucks (%d)", count] forState:UIControlStateNormal];
 }
 

@end;
